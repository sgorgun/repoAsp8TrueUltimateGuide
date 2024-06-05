Imagine a banking application. Create an Asp.Net Core Web Application
that serves bank account details based on the request path.

Consider the following hard-coded bank account details:

> accountNumber = 1001, accountHolderName = "Example Name",
> currentBalance = 5000

  --------------------------------------
  new { property1 = value, property2 =
  --------------------------------------

You can store these details as an anonymous object. Eg: value }

**Example \#1:**

If you receive a HTTP GET request at path "/" (default route), it has to
return welcome message with status code HTTP 200. Request Url: /

Request Method: GET Response Status Code: 200 Response body (output):
Welcome to the Best Bank

**Example \#2:**

If you receive a HTTP GET request at path "/account-details", it has to
return all the details of bank account as Json format as response with
status code HTTP 200.

Request Url: /account-details

Request Method: GET Response Status Code: 200

Response body (output):

> {
>
> "accountNumber": 1001,
>
> "accountHolderName": "Example Name",
>
> "currentBalance": 5000
>
> }

![](media/image1.jpg){width="7.322916666666667in"
height="4.114583333333333in"}

**Example \#3:**

If you receive a HTTP GET request at path "/account-statement", it has
to return a dummy PDF file (assumed as bank statement) as response with
status code HTTP 200.

Request Url: /account-statement

Request Method: GET Response Status Code: 200 Response body (output):
\[some dummy PDF file\]

**Example \#4:**

If you receive a HTTP GET request at path
"/get-current-balance/{accountNumber}", it has to return the
corresponding current balance value as response with status code HTTP
200.

The "accountNumber" should be an int value and should be equal to
"1001".

Request Url: /get-current-balance/1001

Request Method: GET Response Status Code: 200

Response body (output):

5000

![](media/image2.jpg){width="7.322916666666667in"
height="4.114583333333333in"}

**Example \#5:**

If you receive a HTTP GET request at path "/get-current-balance/", if
the "accountNumber" is not supplied, it should return HTTP 404 response.

Request Url: /get-current-balance

Request Method: GET Response Status Code: 404

Response body (output):

> Account Number should be supplied

**Example \#6:**

If you receive a HTTP GET request at path
"/get-current-balance/{accountNumber}", if the "accountNumber" is not
equal to '1001', it should return HTTP 400 response.

Request Url: /get-current-balance/10

Request Method: GET Response Status Code: 400

Response body (output):

> Account Number should be 1001

![](media/image3.jpg){width="7.322916666666667in"
height="4.114583333333333in"}

**Route Constraints:**

The "accountNumber" parameter should be an int value

**Instructions:**

> Create controller(s) with attribute routing.
>
> Use essential route parameters and route constraints.
>
> Use parameter validation when necessary.
>
> Return ContentResult, JsonResult, FileResult and other status code
> results when necessary.
>
> Return the appropriate HTTP response status code, based on above
> examples.

Questions for this assignment
=============================

> Check your source code with Instructor's source code.
https://www.udemy.com/course/asp-net-core-true-ultimate-guide-real-project/learn/practice/1413440/introduction#overview
