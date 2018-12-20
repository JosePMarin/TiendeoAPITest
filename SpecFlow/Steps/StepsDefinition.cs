using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class GETrequestsSteps
    {
        const string BaseUrl = "https://developers.themoviedb.org/";
        const string GetResource = "3/movies/get-top-rated-movies/";
        const string BadResource = "%";
        const string PostResource = "https://developers.themoviedb.org/3/movies/rate-movie";


        RestClient client = new RestClient(BaseUrl);
        const string AppKey = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI2MzNhZWVhOTMxODQzOTE1MzNhNGVlZTE0NThiNzI4YiIsInN1YiI6IjVjMWI3YjA4MGUwYTI2NWY3ODU2NGM3MSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.0jM_4xMtX57Atz2dm2XB3Rsstei9-4S1rCTkhtM2C20";
        const string WrongAppKey = "BadKey";




        [Given(@"I build a (.*) Endpoint for (.*) call")]
        public void GivenIBuildAEndpoint(string param, string call)
        {
            if (param == "good" && call == "GET")
            {
                RestRequest request = new RestRequest(GetResource, Method.GET);
                request.AddHeader("Accept", "application/json");
                request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
            }
            if (param == "bad" && call == "GET")
            {
                RestRequest request = new RestRequest(BadResource, Method.GET);
                request.AddHeader("Accept", "text/html; charset=utf-8");
                request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
            }
            if (param == "good" && call == "POST")
            {
                RestRequest request = new RestRequest(PostResource, Method.POST);
                request.AddHeader("Accept", "application/json");
                request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
            }
            if (param == "bad" && call == "POST")
            {
                RestRequest request = new RestRequest(BadResource, Method.POST);
                request.AddHeader("Accept", "text/html; charset=utf-8");
                request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
            }


        }


        [When(@"I make a (.*) (.*) request")]
        public void WhenIMakeARequest(string param, string call)
        {

            if (param == "good")//Good Endpoint
            {
                if (call=="GET")
                {
                    
                    RestRequest request = new RestRequest(GetResource, Method.GET);
                    request.AddHeader("Accept", "text/html; charset=utf-8");
                    request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
                    var response = client.Execute(request);
                    var content = response.Content;

                    Console.WriteLine(response.ResponseStatus.ToString());

                    Console.WriteLine("Get message Body: " + content);
                }
                if (call == "POST")
                {
                    RestRequest request = new RestRequest(PostResource, Method.POST);
                    request.AddHeader("Accept", "text/html; charset=utf-8");
                    request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(new { value = 8 });
                    var response = client.Execute(request);
                    var content = response.Content;
                    Console.WriteLine(content.ToString());
                    Console.WriteLine(response.ResponseStatus.ToString());

                    Console.WriteLine("Get message Body: " + content);
                }
                
            }

            if (param == "bad")//Bad Endpoint
            {
                if (call== "GET")
                {
                    RestRequest request = new RestRequest(BadResource, Method.GET);
                    request.AddHeader("Accept", "text/html; charset=utf-8");
                    request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
                    var response = client.Execute(request);
                    var content = response.Content;
                }
                
                if(call=="POST")
                {
                    RestRequest request = new RestRequest(BadResource, Method.POST);
                    request.AddHeader("Accept", "text/html; charset=utf-8");
                    request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(new { value = 8 });
                    var response = client.Execute(request);
                    var content = response.Content;
                    Console.WriteLine(content.ToString());
                    Console.WriteLine(response.ResponseStatus.ToString());

                    Console.WriteLine("Get message Body: " + content);
                }

                
                
            }


        }

        
        [Then(@"I receive a (.*) status code for a (.*) call")]
        public void ThenIReceiveAStatusCode(int status_code, string call)
        {
            if (status_code == 200)
            {
                if (call == "GET")
                {
                    RestRequest request = new RestRequest(GetResource, Method.GET);
                    request.AddHeader("Accept", "text/html; charset=utf-8");
                    request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
                    var response = client.Execute(request);
                    int StatusCode = (int)response.StatusCode;
                    Console.WriteLine("Endpoint: " + client.BuildUri(request));
                    Console.WriteLine("status code: " + response.StatusCode + " " + StatusCode);
                    Assert.That(StatusCode.Equals(status_code));
                }
                if (call == "POST")
                {
                    RestRequest request = new RestRequest(PostResource, Method.POST);
                    request.AddHeader("Accept", "text/html; charset=utf-8");
                    request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(new { value = 8 });
                    var response = client.Execute(request);
                    var content = response.Content;
                    Console.WriteLine(content.ToString());
                    Console.WriteLine(response.ResponseStatus.ToString());
                    int StatusCode = (int)response.StatusCode;
                    Console.WriteLine("Get message Body: " + content);
                    Assert.That(StatusCode.Equals(status_code));
                }

            }
            if (status_code == 401)//Wrong AppKey
            {
                if (call == "GET")
                {
                    RestRequest request = new RestRequest(GetResource, Method.GET);
                    request.AddHeader("Accept", "text/html; charset=utf-8");
                    request.AddParameter("Authorization", string.Format("Bearer " + WrongAppKey), ParameterType.HttpHeader);
                    var response = client.Execute(request);
                    int StatusCode = (int)response.StatusCode;
                    Console.WriteLine("Endpoint: " + client.BuildUri(request));
                    Console.WriteLine("status code: " + response.StatusCode + " " + StatusCode);
                    Assert.That(StatusCode.Equals(status_code));

                }
                if (call == "POST")
                {
                    RestRequest request = new RestRequest(PostResource, Method.POST);
                    request.AddHeader("Accept", "text/html; charset=utf-8");
                    request.AddParameter("Authorization", string.Format("Bearer " + WrongAppKey), ParameterType.HttpHeader);
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(new { value = 8 });
                    var response = client.Execute(request);
                    var content = response.Content;
                    Console.WriteLine(content.ToString());
                    Console.WriteLine(response.ResponseStatus.ToString());
                    int StatusCode = (int)response.StatusCode;
                    Console.WriteLine("Get message Body: " + content);
                    Assert.That(StatusCode.Equals(status_code));
                }
            }

            if (status_code == 400)//Wrong Endpoint
            {
                if (call == "GET")
                {
                    RestRequest request = new RestRequest(BadResource, Method.GET);
                    request.AddHeader("Accept", "text/html; charset=utf-8");
                    request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
                    var response = client.Execute(request);
                    int StatusCode = (int)response.StatusCode;
                    Console.WriteLine("Endpoint: " + client.BuildUri(request));
                    Console.WriteLine("status code: " + response.StatusCode + " " + StatusCode);
                    Assert.That(StatusCode.Equals(status_code));
                }

                if (call == "POST")
                {
                    RestRequest request = new RestRequest(BadResource, Method.POST);
                    request.AddHeader("Accept", "text/html; charset=utf-8");
                    request.AddParameter("Authorization", string.Format("Bearer " + AppKey), ParameterType.HttpHeader);
                    request.RequestFormat = DataFormat.Json;
                    request.AddJsonBody(new { value = 8 });
                    var response = client.Execute(request);
                    var content = response.Content;
                    Console.WriteLine(content.ToString());
                    Console.WriteLine(response.ResponseStatus.ToString());
                    int StatusCode = (int)response.StatusCode;
                    Console.WriteLine("Get message Body: " + content);
                    Assert.That(StatusCode.Equals(status_code));
                }



            }
        }
    }
}
