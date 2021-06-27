using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class PuntenComm
    {
        static HttpClient client = new HttpClient();

        public static bool Error;
        public int AccountID { get; set; }

        public int Points { get; set; }

        //Send request to puntenbeheer to subtract cost form user with userID
        public static async Task<Uri> SubstractPoints(int userID, int cost)
        {
            PuntenComm obj = new() { AccountID = userID, Points = cost};
            JsonSerializer.Serialize(obj);            
            HttpResponseMessage response = await client.PutAsJsonAsync("https://devopspuntenbeheer.azurewebsites.net/huren/{{AccountID}}", obj);
            Error = false;
            try 
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException)
            {
                Error = true;
                return response.Headers.Location;
            }
            
            return response.Headers.Location;
        }

        //Send request to puntenbeheer to add cost to user with userID
        public static async Task<Uri> AddPoints(int cost, int userID)
        {
            PuntenComm obj = new() { AccountID = userID, Points = cost };
            JsonSerializer.Serialize(obj);
            HttpResponseMessage response = await client.PutAsJsonAsync("https://devopspuntenbeheer.azurewebsites.net/intakeproducten/{{AccountID}}", obj);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }        
    }
}
