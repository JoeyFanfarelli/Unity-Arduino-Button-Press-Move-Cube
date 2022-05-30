using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports; //Allows us to use serial ports. If not recognized, go to Unity top menu, Edit->Project Settings->Player->Other Settings-> Configuration-> Api compatibility Level. Select .net 4.x

//A simple tech demo. An arduino reads the state of a single button. If it is pushed down, it will move the cube to the left. If not, it will do nothing.
public class ArduinoScript : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM9", 9600);   //Go to Arduino IDE and find which COM port it is connected to. Look at lower right side of the Arduino IDE to see. Second parameter is baud rate. Should match Arduino IDE - 9600.


    public float movementModifier;                      //How much the cube should move with each button press.

    //Open serial port/prepare for data transmission, and set a timeout duration for reading the data stream.
    void Start()
    {
        sp.Open();                  
        sp.ReadTimeout = 1;        
    }
    
    void Update()
    {
    
        if (sp.IsOpen)      //Try/Catch prevents Unity from shutting itself down when it encounters an error.
        {
            try             
            {          
                if (sp.ReadByte() == 1)                 
                {
                    transform.Translate(Vector3.left * movementModifier * Time.deltaTime);   //move the cube to the left.
                    Debug.Log(sp.ReadByte());           //Print out the serial data that is being received by the Arduino.
                }               
            }
            catch(System.Exception)
            {
                                              
            }
        }
    }

}
