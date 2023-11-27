#include <Keypad.h>

const byte ROWS = 4; //four rows
const byte COLS = 7; //four columns
//define the cymbols on the buttons of the keypads
char hexaKeys[ROWS][COLS] = {
 {'1','2','3','4','5','6','7'},   
  {'8','9','M','N','O','P','R'},
  {'S','T','A','B','C','D','E'},
  {'F','G','H','I','J','K','L'}
};
byte rowPins[ROWS] = {A0,A1,A2,A3}; 
byte colPins[COLS] = {2,3,4,5,6,7,8}; 


Keypad customKeypad = Keypad( makeKeymap(hexaKeys), rowPins, colPins, ROWS, COLS); 
void(*resetFunc) (void) = 0;
void setup(){
  Serial.begin(9600);
//  Serial.println("hhhhhh");
}
  
void loop(){
 
//  Serial.println("dashnda");
  if (Serial.available() > 0) {
  char customKey = Serial.read();

//  Serial.println(customKey);

  if(customKey){
    char trig = customKey;
    String aydym1 = "1";
    String strjem1 = aydym1 + customKey;
    Serial.println(strjem1);
   
    while(1){
      char customKey2 = customKeypad.getKey();
      if(customKey2 == trig){
        String aydym = "";
        String Strjem = aydym + trig;
        Serial.println(Strjem);
//         Serial.println("dogry");
//        Serial.print("aydym ");
//        Serial.println(customKey2);
        
        delay(1000);
       resetFunc();
   
        
        
        break;
      }
      else if(customKey2 > 0 & customKey2 != trig){
       Serial.println("q");
//        
        delay(1000);
        
       }
      }
    }
}
}
