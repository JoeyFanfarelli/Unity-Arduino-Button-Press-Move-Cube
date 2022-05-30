int buttonState = 0;

void setup() {
  pinMode(13,INPUT);
  Serial.begin(9600);
}

void loop() {

  buttonState = digitalRead(13);

  if(buttonState == 1){ 
    Serial.write(1);  //Sends the serial data (Unity can accept it in this format)
    Serial.flush();   //Waits for data to send before proceeding in the code.
    delay(20);        //Unity needs a minute to read the input. Prevents false data reading from Unity. Too long, Unity lags. Too short, Unity gets overhwhelmed and lags.
  }


  
}
