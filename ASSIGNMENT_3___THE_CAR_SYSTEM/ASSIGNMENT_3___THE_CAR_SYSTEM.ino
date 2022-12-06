

const int BUTTON_TURNLEFT = 9;
const int BUTTON_TURNRIGHT = 8;
const int PIN_NTC = 15;
const int NTC_R25 = 10000; // the resistance of the NTC at 25'C is 10k ohm
const int NTC_MATERIAL_CONSTANT = 3950; // value provided by manufacturer
const int POT_PIN = 14;
const int MAX_POTVALUE = 10;
const int MIN_POTVALUE = 0;
const int PIN_LDR = 16;
const int LED_RED = 4;
const int LED_GREEN = 5;
const int LED_BLUE = 6;
const int LED_YELLOW = 7;


int prevBtnStateForTurnRight = HIGH;
int prevBtnStateForTurnLeft = HIGH;


bool inNormalMode = true;


void setup() {
  pinMode(PIN_LDR, INPUT);
  pinMode(POT_PIN, INPUT);
  pinMode(BUTTON_TURNLEFT, INPUT_PULLUP);
  pinMode(BUTTON_TURNRIGHT, INPUT_PULLUP);
  pinMode(LED_RED, OUTPUT);
  pinMode(LED_GREEN, OUTPUT);
  pinMode(LED_BLUE, OUTPUT);
  pinMode(LED_YELLOW, OUTPUT);
  Serial.begin(9600);

}


unsigned long nextTempSentTime = 0;
void handleTemperature()
{
  if (millis() > nextTempSentTime) {
    float resistance   = (float)analogRead(PIN_NTC) * NTC_R25 / (1024 - analogRead(PIN_NTC)); // Calculate resistance
    /* Calculate the temperature according to the following formula. */
    float temperature  = 1 / (log(resistance / NTC_R25) / NTC_MATERIAL_CONSTANT + 1 / 298.15) - 273.15;
    Serial.println(temperature);
    nextTempSentTime = millis() + 5000;
  }
}

int getPotValue()
{
  int potValue = map(analogRead(POT_PIN), 0, 1023, MIN_POTVALUE, MAX_POTVALUE );
  return potValue;
}


bool automaticLightIsOn = false;
void handleLightSensor()
{
  float displayLightSensor = analogRead(PIN_LDR);

  if (displayLightSensor < 500 && !automaticLightIsOn)
  {
    automaticLightIsOn = true;
    digitalWrite(LED_YELLOW, HIGH);
    Serial.println("ON");
  }
  else if (displayLightSensor > 800 && automaticLightIsOn) {
    automaticLightIsOn = false;
    digitalWrite(LED_YELLOW, LOW);
    Serial.println("OFF");
  }
}

bool turningLeft = false;
bool turningRight = false;
unsigned long leftBlinkTime = 0;
bool leftBlinkState = false;

int handleLeftIndicators()
{
  int btnStateTurnLeft = digitalRead(BUTTON_TURNLEFT);

  if (btnStateTurnLeft != prevBtnStateForTurnLeft)
  {
    if (btnStateTurnLeft == LOW) {
      if (getPotValue() < 5)
      {
        turningLeft = true;
      }
    }
    delay(50);
  }
  prevBtnStateForTurnLeft = btnStateTurnLeft;

  if (turningLeft) {
    if (getPotValue() > 5) {
      turningLeft = false;
      leftBlinkState = false;
      leftBlinkTime = 0;
      if (inNormalMode) digitalWrite(LED_BLUE, leftBlinkState);
    }
    else if (millis() > leftBlinkTime) {
      leftBlinkState = !leftBlinkState;
      if (inNormalMode) digitalWrite(LED_BLUE, leftBlinkState);
      leftBlinkTime = leftBlinkTime + 1000;
    }
  }
}


unsigned long rightBlinkTime = 0;

int handleRightIndicators()
{
  int btnStateTurnRight = digitalRead(BUTTON_TURNRIGHT);

  if (btnStateTurnRight != prevBtnStateForTurnRight)
  {
    if (btnStateTurnRight == LOW) {
      if (getPotValue() > 5)
      {
        turningRight = true;
      }
    }
    delay(50);
  }
  prevBtnStateForTurnRight = btnStateTurnRight;

  if (turningRight) {
    if (getPotValue() < 5) {
      turningRight = false;
      leftBlinkState = false;
      leftBlinkTime = 0;
      if (inNormalMode) digitalWrite(LED_GREEN, leftBlinkState);
    }
    else if (millis() > rightBlinkTime) {
      leftBlinkState = !leftBlinkState;
      if (inNormalMode) digitalWrite(LED_GREEN, leftBlinkState);
      rightBlinkTime = rightBlinkTime + 1000;
    }
  }
}

void obtainNewMode() {
  if (Serial.available()) {
    String message = Serial.readStringUntil('\n');
    if (message == "hazard") {
      inNormalMode = false;
    } else if (message = "normal") {
      inNormalMode = true;
      digitalWrite(LED_GREEN, LOW);
      digitalWrite(LED_BLUE, LOW);
      digitalWrite(LED_RED, LOW);
    }
  }
}

unsigned long hazardBlinkTime = 0;
bool hazardBlinkState = false;
void handleHazardMode()
{
   if (!inNormalMode) {
    if (millis() > hazardBlinkTime) {
      hazardBlinkState = !hazardBlinkState;
      digitalWrite(LED_BLUE, hazardBlinkState);
      digitalWrite(LED_RED, hazardBlinkState);
      digitalWrite(LED_GREEN, hazardBlinkState);
      hazardBlinkTime = hazardBlinkTime + 500;
    }
   }
}
void loop() {
  obtainNewMode();
  handleLightSensor();
  handleTemperature();
  handleLeftIndicators();
  handleRightIndicators();
  handleHazardMode();
}
