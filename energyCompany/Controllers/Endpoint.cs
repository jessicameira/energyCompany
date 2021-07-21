using energyCompany.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace energyCompany.controllers
{
    class Endpoint : IEndpoint
    {
        public string SerialNumber { get; set; }
        public int ModelId { get; set; }
        public string ModelDescription { get; set; }
        public int Number { get; set; }
        public string FirmwareVersion { get; set; }
        public int State { get; set; }
        public string StateDescription { get; set; }

        private List<Endpoint> listEndPoint = new List<Endpoint>();
        public void Create(string serialNumber, int modelId, int number, string firmwareVersion, int state)
        {
            string stateDescription = setStateDescription(state);

            string modelDescription = setModelDescription(modelId);

            bool validEndpoint = validateEndpoint(serialNumber);
            if (validEndpoint == true)
            {
                listEndPoint.Add(new Endpoint() { SerialNumber = serialNumber, ModelId = modelId, ModelDescription = modelDescription, Number = number, FirmwareVersion = firmwareVersion, State = state, StateDescription = stateDescription });
                Console.WriteLine("Successful registration");
            }
            foreach (Endpoint ep in listEndPoint)
            {
                Console.WriteLine($"Serial Number: {ep.SerialNumber} - ModelId: {ep.ModelId} | {ep.ModelDescription} - Number: {ep.Number} - Firmware Version: {ep.FirmwareVersion} - State: {ep.State} - {ep.StateDescription}.");
            }
            
            return;
        }

        public void Delete(string serialNumber)
        {
            try
            {
                Endpoint list = listEndPoint.First(item => item.SerialNumber.Equals(serialNumber));

                listEndPoint.Remove(list);

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: Endpoint not founded!");
            }

            return;
        }

        public void Update(string serialNumber, int state)
        {
            string newState = setStateDescription(state);
            try
            {
                Endpoint idx = listEndPoint.Single(item => item.SerialNumber.Equals(serialNumber));
                idx.State = state;
                idx.StateDescription = newState;

                Console.WriteLine("Endpoint Updated!");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: Endpoint not founded!");

            }

            Console.WriteLine("Endpoint Updated!");

            return;
        }

        public void ListAll()
        {
            foreach (Endpoint ep in listEndPoint)
            {
                Console.WriteLine($"Serial Number: {ep.SerialNumber} - ModelId: {ep.ModelId} || {ep.ModelDescription} - Number: {ep.Number} - Firmware Version: {ep.FirmwareVersion} - State: {ep.State} - {ep.StateDescription}.");
            }
            return;
        }

        public void FindBy(string serialNumber)
        {
            try
            {
                Endpoint idx = listEndPoint.Single(item => item.SerialNumber.Equals(serialNumber));

                Console.WriteLine($"Serial Number: {idx.SerialNumber} - ModelId: {idx.ModelId} || {idx.ModelDescription} - Number: {idx.Number} - Firmware Version: {idx.FirmwareVersion} - State: {idx.State} - {idx.StateDescription}.");
            }
            catch
            {
                Console.WriteLine("Endpoint Not Founded!");
            }

            return;
        }

        public string setModelDescription(int modelId)
        {
            string modelDescription = "";
            if (modelId == 16)
            {
                modelDescription = "NSX1P2W";

            }
            if (modelId == 17)
            {
                modelDescription = "NSX1P3W";
            }
            if (modelId == 18)
            {
                modelDescription = "NSX2P3W";
            }
            if (modelId == 19)
            {
                modelDescription = "NSX2P4W";
            }
            return modelDescription;
        }

        public string setStateDescription(int state)
        {
            string stateDescription = "";
            if (state == 0)
            {
                stateDescription = "Disconnected";

            }
            if (state == 1)
            {
                stateDescription = "Connected";
            }
            if (state == 2)
            {
                stateDescription = "Armed";
            }

            return stateDescription;
        }

        bool validateEndpoint(string serialnumber)
        {
            try
            {
                Endpoint newAdd = listEndPoint.Single(item => item.SerialNumber.Equals(serialnumber));
                Console.WriteLine("Endpoint already exists!");
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
