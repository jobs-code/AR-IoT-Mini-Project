/* Comment this out to disable prints and save space */
#define BLYNK_PRINT Serial

/* Fill-in your Template ID (only if using Blynk.Cloud) */
//#define BLYNK_TEMPLATE_ID   "YourTemplateID"

#include <ESP8266WiFi.h>
#include <BlynkSimpleEsp8266_SSL.h>
#include <DHT.h>

#define RELAY_PIN 5  // Relay pin
#define PWM_PIN 16    // PWM pin
#define DHTPIN 4      // DHT11 pin
#define DHTTYPE DHT11 // DHT 11

// You should get Auth Token in the Blynk App.
// Go to the Project Settings (nut icon).
char auth[] = "t9SRm0uM7lAQNHJ0bJ8JsFlaWRzapMxh";

// Your WiFi credentials.
// Set password to "" for open networks.
char ssid[] = "Galaxy j";
char pass[] = "556677889900";

DHT dht(DHTPIN, DHTTYPE);
BlynkTimer timer;

void sendSensor()
{
  float h = dht.readHumidity();
  float t = dht.readTemperature(); // or dht.readTemperature(true) for Fahrenheit

  if (isnan(h) || isnan(t))
  {
    Serial.println("Failed to read from DHT sensor!");
    return;
  }

  // You can send any value at any time.
  // Please don't send more than 10 values per second.
  Blynk.virtualWrite(V4, h);
  Blynk.virtualWrite(V5, t);
}

BLYNK_WRITE(V1)
{
  int pinValue = param.asInt();
  analogWrite(D1, pinValue);
  Blynk.virtualWrite(V1, pinValue);
}

BLYNK_WRITE(V3)
{
  int pinValue = param.asInt();
  analogWrite(D6, pinValue);
  Blynk.virtualWrite(V3, pinValue);
}

void setup()
{
  // Debug console
  Serial.begin(115200);
  Blynk.begin(auth, ssid, pass);
  dht.begin();
  timer.setInterval(1000L, sendSensor);
  pinMode(PWM_PIN, OUTPUT);
  pinMode(RELAY_PIN, OUTPUT);
}

void loop()
{
  Blynk.run();
  timer.run();
}
