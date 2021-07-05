Ex: DateTime.Tostring(dd\\/MM\\/yyyy)

https://www.c-sharpcorner.com/UploadFile/manas1/string-to-datetime-conversion-in-C-Sharp/


// Convert a null string.  
string dateString = null;  
CultureInfo provider = CultureInfo.InvariantCulture;  
// It throws Argument null exception  
DateTime dateTime10 = DateTime.ParseExact(dateString, "mm/dd/yyyy", provider);  

<%= String.Format("{specifier}", DateTime.Now) %>

Specifier ---> Description ---> Output
d ---> Short Date ---> 08/04/2007
D ---> Long Date ---> 08 April 2007
t ---> Short Time ---> 21:08
T ---> Long Time ---> 21:08:59
f ---> Full date and time ---> 08 April 2007 21:08
F ---> Full date and time (long) ---> 08 April 2007 21:08:59
g ---> Default date and time ---> 08/04/2007 21:08
G ---> Default date and time (long) ---> 08/04/2007 21:08:59
M ---> Day / Month ---> 08 April
r ---> RFC1123 date ---> Sun, 08 Apr 2007 21:08:59 GMT
s ---> Sortable date/time ---> 2007-04-08T21:08:59
u ---> Universal time, local timezone ---> 2007-04-08 21:08:59Z
Y ---> Month / Year ---> April 2007
d ---> Day ---> 8
dd ---> Day ---> 08
ddd ---> Short Day Name ---> Sun
dddd ---> Full Day Name ---> Sunday
h ---> without leading zero (12 hour) ---> 9
hh ---> 2 digit hour (12 hour)---> 09
H ---> without leading zero (24 hour) ---> 9
HH ---> 2 digit hour (24 hour) ---> 21
m ---> without leading zero (minute) ---> 8
mm ---> 2 digit minute ---> 08
M ---> Month ---> 4
MM ---> Month ---> 04
MMM ---> Short Month name ---> Apr
MMMM ---> Month name ---> April
s ---> without leading zero (seconds) ---> 9
ss ---> seconds ---> 59
tt ---> AM/PM ---> PM
yy ---> 2 digit year ---> 07
yyyy ---> 4 digit year ---> 2007
: ---> seperator, e.g. {0:hh:mm:ss} ---> 09:08:59
/ ---> seperator, e.g. {0:dd/MM/yyyy} ---> 08/04/2007