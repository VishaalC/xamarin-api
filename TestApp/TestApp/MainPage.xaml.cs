using System;
using RestSharp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace TestApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void HandleClick(object sender, EventArgs e)
        {
            Label label = this.FindByName<Label>("dataLabel");
            var options = new RestClientOptions("https://api.businesscentral.dynamics.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/v2.0/10aaae17-22ab-4ba0-a1ea-88832814d2a9/Production/ODataV4/Company('CRONUS%20IN')/TopCustomerOverview", Method.Get);
            request.AddHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Ii1LSTNROW5OUjdiUm9meG1lWm9YcWJIWkdldyIsImtpZCI6Ii1LSTNROW5OUjdiUm9meG1lWm9YcWJIWkdldyJ9.eyJhdWQiOiJodHRwczovL2FwaS5idXNpbmVzc2NlbnRyYWwuZHluYW1pY3MuY29tIiwiaXNzIjoiaHR0cHM6Ly9zdHMud2luZG93cy5uZXQvMTBhYWFlMTctMjJhYi00YmEwLWExZWEtODg4MzI4MTRkMmE5LyIsImlhdCI6MTY3Njg5MzYwMywibmJmIjoxNjc2ODkzNjAzLCJleHAiOjE2NzY4OTgzMDMsImFjciI6IjEiLCJhaW8iOiJBVlFBcS84VEFBQUFDdlVvNm9LSmRJU0UvMWd0M21KQmtOblFEWElzSXJwSHh6cy90eGJnQ3E5YjkxNHdvcVYrMmNwQWkzVTB0MUNjekVXZzdudmRSU0N3MVRtbmlJa21NTWdJbmpGcCs1S1h6c3BLKzJhVE1NND0iLCJhbXIiOlsicHdkIiwibWZhIl0sImFwcGlkIjoiMTRkZDY0ZDMtMmVjOS00MTFhLWE1MzctMjNmN2E4YjIwZGY4IiwiYXBwaWRhY3IiOiIxIiwiZmFtaWx5X25hbWUiOiJrIiwiZ2l2ZW5fbmFtZSI6Im1vaGFtZWQiLCJpcGFkZHIiOiI0OS4zNy4yMTEuMTUxIiwibmFtZSI6Im1vaGFtZWQgayIsIm9pZCI6IjM1M2U4NDBlLWY2NDEtNDdkOC04ODYzLWJlMTVjOTEzOGVjMiIsInB1aWQiOiIxMDAzMjAwMjAwOUU5NjAzIiwicmgiOiIwLkFWVUFGNjZxRUtzaW9FdWg2b2lES0JUU3FUM3ZiWmxzczFOQmhnZW1fVHdCdUotSUFKay4iLCJzY3AiOiJGaW5hbmNpYWxzLlJlYWRXcml0ZS5BbGwgdXNlcl9pbXBlcnNvbmF0aW9uIiwic3ViIjoiXzZaV210Qlk4MzJ1ejhSMzlnVFVGRGR3SzV5TGxvcW1fQm43TU9BX2dNNCIsInRpZCI6IjEwYWFhZTE3LTIyYWItNGJhMC1hMWVhLTg4ODMyODE0ZDJhOSIsInVuaXF1ZV9uYW1lIjoibW9oYW1lZGtAeno4Mzgub25taWNyb3NvZnQuY29tIiwidXBuIjoibW9oYW1lZGtAeno4Mzgub25taWNyb3NvZnQuY29tIiwidXRpIjoiempQWUdvTHh0RVNCWFFmNWdxVkJBQSIsInZlciI6IjEuMCIsIndpZHMiOlsiNjJlOTAzOTQtNjlmNS00MjM3LTkxOTAtMDEyMTc3MTQ1ZTEwIiwiYjc5ZmJmNGQtM2VmOS00Njg5LTgxNDMtNzZiMTk0ZTg1NTA5Il19.buemqDItIvEQNEka4w_zH4GrYlj7A1blyct3BqqqsxujRUL_C-4txzXRQJzbz5pnbr3bEqdOooTb9uWY1g8mHI9rgCgmPfrlZ7w_rrK3ZPSYobuZi4hbUKws3APdseEE64GMjS5CHwSKQX9WqYRMvKMlOzBUWciEUOJ_YiRvRt77ae_NB7BMSVUq4qY0c7Te7sE3viQDjAF5NoBgwlkI6MPD6XGxWlld2vf7zH-HKZws9nCGxHeGuA4pAoyV4aoZ7TT9gEt56t2hI7jVwHOYu_TmM0JTBZgTVI3TJIapT-toIuRc28g6SF1gnrLWI6_Pq0Aav1OhcftkPRUZ9DpAJg");
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response =  client.Execute(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(response.Content);

            Label newL = new Label();
            //newL.Text = response.Content;
            //DataList.Children.Add(newL);

            if(response.IsSuccessStatusCode) 
            {
                string json = response.Content.ToString();
                var jsonObject = JObject.Parse(json);

                var odatacontext = jsonObject["@odata.context"];
                var value = jsonObject["value"];

                Debug.WriteLine(value);
                Debug.WriteLine(odatacontext);
                newL.Text = odatacontext.ToString();
                DataList.Children.Add(newL);

                var jsonArray = JArray.Parse(value.ToString());
                StringBuilder stringB = new StringBuilder();
                foreach(var token in jsonArray)
                {
                    stringB.Append("" + token["Name"] + "\n");
                   
                }
                label.Text = stringB.ToString();

            }

          
        }
    }
}
