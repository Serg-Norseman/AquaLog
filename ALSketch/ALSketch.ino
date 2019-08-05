int counter = 0;
int led = 13;

void setup() {
  Serial.begin(9600);
  pinMode(led, OUTPUT);
}

void loop() {
  counter = counter + 1;
  String pingMsg = "Ping counter from Arduino: ";
  pingMsg += counter;
  Serial.println(pingMsg);

  if (Serial.available() > 0) {
    char cmdChar = Serial.read();
    switch (cmdChar) {
      case '1':
        digitalWrite(led, HIGH);
        break;
      case '0':
        digitalWrite(led, LOW);
        break;
    }
  }
  delay(300);
}
