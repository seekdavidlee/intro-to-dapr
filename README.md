# Introduction
This is an introduction to DAPR (Distributed Application Runtime) in a .NET Web API project. For demonstrating the pub/sub capabilities, we will be using Azure Service Bus. 

# Steps
To run the demo, please follow the steps below.

1. Create an Azure Service Bus. Basic SKU should be good.
2. Create a Queue named weather.
3. Create a policy with "Send" permission.
4. Create a file called secrets.json with the following content and copy the policy connection string.
```
{
	"sb-connectionString": "<Copy the policy connection string here>"
}
```
5. Run the following command which will show DAPR running alongside with /weather API. Note that this command should be executed relative to where the components folder is located.
```
dapr run -a daprapi -d components dotnet run
```
6. We will use PowerShell to execute a HTTP PUT with a payload to the API. Run the following command to create Object. The port may change, so please take note of the console output in the previous step.
```
Invoke-RestMethod -Method Put -Body (ConvertTo-Json $obj) -UseBasicParsing -Uri https://localhost:7068/weatherforecast -ContentType "application/json"
```
7. If there are no errors, we can review the console logs from the DAPR console window and check if there are any errors.
8. Lastly, we can go back to Azure Service Bus and run a PEEK to check for our message that we just published. 