using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NewBehaviourScript : MonoBehaviour
{
    //declaring variables
    private Rigidbody rb;
    private bool launch;
    public bool check;
    float gamma;
    float P;
    public float V;
    public float Vw;
    float Va;
    public float De;
    public float Ds;
    float Ae;
    float As;
    float Ar;
    float Patm;
    float rhow;
    public float Thrust;
    public float P0;
    float Va0;
    float Pold;
    float dV_dt;
    float T;
    float rho;
    float ma;
    public float R;
    float rho_e;
    float v_e;
    float mdot;
    float Te;
    float M;
    float rho0;
    public float mb;
    public float height;
    bool check2;
    bool check3;
    string output;
    public float startTime;
    public static List<float> ThrustList;
    public static List<float> TimeList;
    public bool test;
    public float v;

    public void AdjustV(float newV)
    {
        //obtaining bottle volume from slider
        V = newV/1000; 
    }

    public void AdjustVw(float newVw)
    {
        //obtaining water volume from slider
        Vw = newVw / 1000;
    }

    public void AdjustP(float newP)
    {
        //obtaining initial bottle pressure from slider
        P0 = newP;
    }

    public void AdjustDe(float newDe)
    {
        //obtaining nozzle diameter from slider
        De = newDe/1000;
    }

    public void AdjustDs(float newDs)
    {
        //obtaining bottle diameter from slider
        Ds = newDs / 100;
    }

    //Start is called when the script is enabled
    public void Start()
    {
        rb = GetComponent<Rigidbody>(); //getting the rigidbody component from the game object

        SetDefaults();

        using (StreamWriter writer = new StreamWriter(@"C:\Users\paras\Documents\University\Individual Project\Water Rocket\Water Rocket\Assets\Text Output.csv", false))
        { } //clears the csv file

    }

    //Update is called once per frame
    public void Update()
    {
        height = transform.position.y;
        v = rb.velocity.magnitude;
    }

    public void FixedUpdate()
    {
        if (check == false || test)
        {
            //Prevents any unwanted movement before launch or during static test 
            HoldPosition();
        }

        rb.mass = mb + ma + 1000 * Vw; //updating mass

        if ((Vw > 0) && ((P - Patm) > 1e3) && check)
        {
            //for the water propelled phase

            if (check2)
            {
                //calculating the inital thrust at t=0
                startTime = Time.time;
                Thrust = 2 * Ae * (P - Patm) / (1 - Mathf.Pow(Ar, 2));
                check2 = false;
            }
            else
            {
                //solving the differential equations for thrust via a forward difference method
                dV_dt = Mathf.Pow((2 * (P - Patm)) / (rhow * (1 - Mathf.Pow(Ar, 2))), 0.5f);
                P = P - ((gamma * P0 * (Mathf.Pow(Va0, gamma)) * Ae) / (Mathf.Pow(Va, (gamma + 1)))) * dV_dt * Time.fixedDeltaTime;
                Va = Va + Ae * dV_dt * Time.fixedDeltaTime;
                Thrust = 2 * Ae * (P - Patm) / (1 - Mathf.Pow(Ar, 2));
                
                Vw = V - Va; //updating the volume of water
            }

        }

        else if ((Vw <= 0) && ((Patm / P) < 0.5283) && check)
        {
            //for sonic conditions at nozzle

            if (check3)
            {
                //calculating density and temperature
                rho = ma / Va;
                T = P / (rho * R);
            }

            rho_e = 0.6339f * rho;
            Te = 0.8333f * T;
            v_e = Mathf.Sqrt(gamma * R * Te);
            UpdateThrustetc();
            check3 = false;
        }

        else if ((Vw <= 0) && ((P - Patm) > 1e3) && check)
        {
            //for subsonic conditions at nozzle

            M = Mathf.Sqrt((2 / (gamma - 1)) * (Mathf.Pow((P / Patm), ((gamma - 1) / gamma)) - 1));
            rho_e = rho / Mathf.Pow((1 + ((gamma - 1) / 2) * M * M), (1 / (gamma - 1)));
            Te = T / (1 + ((gamma - 1) / 2) * M * M);
            v_e = M * Mathf.Sqrt(gamma * R * Te);
            UpdateThrustetc();
        }

        else
        {
            Thrust = 0;
        }

        if (!test)
        {
            rb.AddForce(new Vector3(0, Thrust, 0), ForceMode.Force); //Applying thrust to rocket
        }

        if(Thrust != 0)
        {
            SaveToFile();
            ThrustList.Add(Thrust);
            TimeList.Add(Time.time-startTime);
        }
    }


    private void SetDefaults()
    {
        //setting constants and default values
        gamma = 1.4f;
        R = 287.1f;
        P0 = 302000f;
        V = 0.002f;
        Vw = 0.0005f;
        De = 0.0215f;
        Ds = 0.106f;
        Patm = 101325f;
        rhow = 1000f;
        T = 293;
        mb = 0.06f;
        ThrustList = new List<float>(); //list stores thrust values for graph
        TimeList = new List<float>(); //list stores time values for graph

        test = false; //value states whether it is a static test
        check = false; //value states whether rocket has been launched
        check2 = true; //used for calculating thrust at t=0s
        check3 = true; //used for calucuating properties for the instant where the water has been exhausted
    }

    private void HoldPosition()
    {
        //fixing position when rocket has not been launched
        rb.freezeRotation = true;
        rb.transform.position = new Vector3(0f, 0.709f, 0f);
        rb.velocity = new Vector3(0f, 0f, 0f);
    }

    public void Launch()
    {
        //executes when user presses launch button

        if (check == false) //ensures that pressing launch button mid-flight has no effect
        {
            //calculating areas
            Ae = 0.25f * 3.1415926f * Mathf.Pow(De, 2f);
            As = 0.25f * 3.1415926f * Mathf.Pow(Ds, 2f);
            Ar = Ae / As;

            Va0 = V - Vw;
            Va = Va0;
            P = P0;
            
            //calculating density and mass of air
            rho = P0 / (T * R);
            rho0 = rho;
            ma = rho * Va0;

            //calculating initial total mass
            rb.mass = mb + ma + 1000 * Vw;

            check = true;
        }
    }

    public void UpdateThrustetc()
    {
        //updating values in the air propulsion phase
        mdot = rho_e * Ae * v_e;
        Thrust = v_e * mdot;
        ma = ma - mdot * Time.fixedDeltaTime;
        rho = ma / Va;
        P = P0 * Mathf.Pow((rho / rho0), gamma);
        T = P / (rho * R);
    }

    public void Reset()
    {
        //resets simulation ame on user request
        Start();
    }

    public void SaveToFile()
    { 
        //writing thrust-time output to csv file for further analysis

        using (StreamWriter writer = new StreamWriter(@"C:\Users\paras\Documents\University\Individual Project\Water Rocket\Water Rocket\Assets\Text Output.csv", true))
        {
            output = Thrust.ToString() + "," + (Time.time-startTime).ToString();
            writer.WriteLine(output);
            writer.Close();
        }
    }

    public void Test()
    {
        test = true;
        Launch();
    }
}