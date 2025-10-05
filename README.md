Hur programmet funkar:

För att använda programmet måste du börja med att skapa ett konto genom att skriva in din e-postadress och ett lösenord. Detta konton sparas i filen users.txt.
Logga in. Efter att kontot har skapats loggar du in med samma e-post och lösenord. Vid lyckad inloggning kommer du till huvudmenyn.
Huvudmenyn. Efter inloggad visas följande meny:
1. Add an item
Du lägger till ett nytt föremål med namn och beskrivning. Föremålet kopplas till användaren som ägare och sparas även i items.txt

2. Show items in inventory 
Visar en lista över alla tillagda föremål, inklusive namn, beskrivning och ägare.

3. Make a trade
En undermeny öppnas som har med dessa alternativ:
3,1. 
Välj vem som skickar bytet
3,2.
Välj vem som ska ta emot bytet
3,3.
Välj status för bytet
3,4.
välj föremål för bytet
3,5
om man väljer 3,5 får man upp all info från tidigare val och så skapas bytet och sparas i listan "trades"

4. Browse trade requests
Visar alla byten som har statusen "Pending". Du får möjligheten att acceptera eller neka ett byte genom att välja den med sitt nummer. Om du accepterar bytet ändras statusen till "Accepted". Om du nekar bytet ändras statusen till "Denied".

5. Browse completed trades
Visar alla byten som har statusen "Accepted" eller "Denied"


6. Logout
Loggar ut användaren så att en ny kan skapa konto och logga in.

Implementationsval:

Jag har valt att programmet använder sig av tre huvudklasser: User- representerar en användare med användarnamn och lösenord, Item- representerar ett föremål som användaren kan lägga till och byta bort och Trade- representerar en bytesförfrågan mellan två användare. Kändes mer logiskt att bara använda sig utav klasser och inte ett interface då dessa har olika funktioner.

Jag har också valt att ha en Enum som kallas TradeStatus för att definiera vilka lägen en trade kan ha (pending, accepted eller denied).

Jag har använt mig av tre stycken listor för att lagra användare, items och trades. Detta för att göra det möjligt att lagra flera objekt av samma typ och enkelt kunna använda dessa flera gånger t.ex i loopar.

När det kommer till filhantering har jag bara använt mig av simpla textfiler. T.ex. users.txt och items.txt för att kunna ha kvar information om user och item trots att man skulle logga ut.

När det kommer till själva strukturen använder programmet switches och cases för menyer och undermenyer. Detta för att det är det jag har använt mest tidigare och jag tycker att det get en ganska enkel struktur att följa.