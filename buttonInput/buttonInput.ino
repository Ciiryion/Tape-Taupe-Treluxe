#define BUTTON0 0
#define BUTTON45 1
#define BUTTON90 2
#define BUTTON135 3
#define BUTTON180 4

int button0State;
int button45State;
int button90State;
int button135State;
int button180State;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  

  pinMode(BUTTON0, INPUT);
  digitalWrite(BUTTON0, HIGH);
  pinMode(BUTTON45, INPUT);
  digitalWrite(BUTTON45, HIGH);
  pinMode(BUTTON90, INPUT);
  digitalWrite(BUTTON90, HIGH);
  pinMode(BUTTON135, INPUT);
  digitalWrite(BUTTON135, HIGH);
  pinMode(BUTTON180, INPUT);
  digitalWrite(BUTTON180, HIGH);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(digitalRead(BUTTON0) == LOW){
    button0State = 1;
  }
  else{
    button0State = 0;
  }
  if(digitalRead(BUTTON45) == LOW){
    button45State = 1;
  }
  else{
    button45State = 0;
  }
  if(digitalRead(BUTTON90) == LOW){
    button90State = 1;
  }
  else{
    button90State = 0;
  }
  if(digitalRead(BUTTON135) == LOW){
    button135State = 1;
  }
  else{
    button135State = 0;
  }
  if(digitalRead(BUTTON180) == LOW){
    button180State = 1;
  }
  else{
    button180State = 0;
  }
  String message = "button 0 : " + String(button0State) + " | button 45 : " + String(button45State) + " | button 90 : " + String(button90State) + " | button 135 : " + String(button135State) + " | button 180 : " + String(button180State);
  Serial.println(message);
  delay(10);
}
