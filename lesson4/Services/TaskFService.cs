using Taskking.Models;
using Taskking.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace Taskking.Services
{
    public class TaskFService : ITaskService
    {
        List<Taskk> Taskkes { get; }
        private string filePath;
        public TaskFService(IWebHostEnvironment webHost)
        {
            this.filePath = Path.Combine(webHost.ContentRootPath, "Data", "Taskk.json");
            using (var jsonFile = File.OpenText(filePath))
            {
                Taskkes = JsonSerializer.Deserialize<List<Taskk>>(jsonFile.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        private void saveToFile()
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(Taskkes));
        }
        public List<Taskk> GetAll() => Taskkes;

        public Taskk Get(int id) => Taskkes.FirstOrDefault(p => p.Id == id);

        public int Post(Taskk Taskk)
        {
            Taskk.Id = Taskkes.Count() + 1;
            Taskkes.Add(Taskk);
            saveToFile();
            return Taskk.Id;   
        }

        public void Delete(int id)
        {
            var Taskk = Get(id);
            if (Taskk is null)
                return;

            Taskkes.Remove(Taskk);
            saveToFile();
        }

        public void Put(Taskk Taskk)
        {
            var index = Taskkes.FindIndex(p => p.Id == Taskk.Id);
            if (index == -1)
                return;

            Taskkes[index] = Taskk;
            saveToFile();
        }

        public int Count => Taskkes.Count();
    }
}