#define BUTTON1 7

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);

  pinMode(BUTTON1, INPUT);
  digitalWrite(BUTTON1, HIGH);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(digitalRead(BUTTON1) == LOW){
    Serial.println("1");
  }
  else{
    Serial.println("0");
  }
  delay(10);
}
