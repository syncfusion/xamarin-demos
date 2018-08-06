#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfSchedule.XForms;
using Syncfusion.SfDataGrid.XForms;

namespace PatientMonitor
{
    class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {

            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<Patient> Patients { get; set; }

		public ObservableCollection<Appointment> Appointments { get; set; }


        public HomeViewModel()
        {
            this.IntializePatients();
           
            this.IntializeAppoitments();
        }

        void IntializePatients()
        {
            ObservableCollection<Patient> patientDetails = new ObservableCollection<Patient>();
            var assembly = typeof(GridViewPage).Assembly;
            patientDetails.Add(new Patient() { Name = "Jessie Mcferron", Image = ImageSource.FromResource("PatientMonitor.Images.Image1.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Erik Edgemon", Image = ImageSource.FromResource("PatientMonitor.Images.Image2.png",assembly) });
            patientDetails.Add(new Patient() { Name = "Christian Tilson", Image = ImageSource.FromResource("PatientMonitor.Images.Image3.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Jessie Badgley", Image = ImageSource.FromResource("PatientMonitor.Images.Image4.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Ted Zinke", Image = ImageSource.FromResource("PatientMonitor.Images.Image5.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Julio Ice", Image = ImageSource.FromResource("PatientMonitor.Images.Image6.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Clayton Lillibridge", Image = ImageSource.FromResource("PatientMonitor.Images.Image7.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Mathew Lechler", Image = ImageSource.FromResource("PatientMonitor.Images.Image8.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Cody Paskett", Image = ImageSource.FromResource("PatientMonitor.Images.Image13.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Nelson Donnellan", Image = ImageSource.FromResource("PatientMonitor.Images.Image10.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Alejandra Mescher", Image = ImageSource.FromResource("PatientMonitor.Images.Image11.png", assembly) });

            patientDetails.Add(new Patient() { Name = "Darcy Mascio", Image = ImageSource.FromResource("PatientMonitor.Images.Image7.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Clayton Lebaron", Image = ImageSource.FromResource("PatientMonitor.Images.Image8.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Javier Vanleuven", Image = ImageSource.FromResource("PatientMonitor.Images.Image9.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Allan Quarterman", Image = ImageSource.FromResource("PatientMonitor.Images.Image14.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Kelly Barga", Image = ImageSource.FromResource("PatientMonitor.Images.Image10.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Lance Piotrowski", Image = ImageSource.FromResource("PatientMonitor.Images.Image11.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Zazueta", Image = ImageSource.FromResource("PatientMonitor.Images.Image4.png", assembly) });
            patientDetails.Add(new Patient() { Name = "JKarina Ziolkowski", Image = ImageSource.FromResource("PatientMonitor.Images.Image1.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Tameka Douse", Image = ImageSource.FromResource("PatientMonitor.Images.Image6.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Tyrone Hadfield", Image = ImageSource.FromResource("PatientMonitor.Images.Image3.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Gay Roeser", Image = ImageSource.FromResource("PatientMonitor.Images.Image4.png", assembly) });

            patientDetails.Add(new Patient() { Name = "Clayton Lokey", Image = ImageSource.FromResource("PatientMonitor.Images.Image12.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Karina Ziolkowski", Image = ImageSource.FromResource("PatientMonitor.Images.Image13.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Tameka Douse", Image = ImageSource.FromResource("PatientMonitor.Images.Image14.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Allan Hoefler", Image = ImageSource.FromResource("PatientMonitor.Images.Image2.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Louisa Fargo", Image = ImageSource.FromResource("PatientMonitor.Images.Image6.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Tyrone Hadfield", Image = ImageSource.FromResource("PatientMonitor.Images.Image3.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Laconte", Image = ImageSource.FromResource("PatientMonitor.Images.Image1.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Alana Barranco", Image = ImageSource.FromResource("PatientMonitor.Images.Image6.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Darryl Saunier", Image = ImageSource.FromResource("PatientMonitor.Images.Image10.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Fernando Kirschbaum", Image = ImageSource.FromResource("PatientMonitor.Images.Image4.png", assembly) });
            patientDetails.Add(new Patient() { Name = "Fernando Kirschbaum", Image = ImageSource.FromResource("PatientMonitor.Images.Image5.png", assembly) });

            for (int i=0;i< patientDetails.Count;i++)
            {
                Patient patient = patientDetails[i];
                patient.RNo = (i + 1);
                patient.Observations = this.GetRandomObservations();
            }

            this.Patients = patientDetails;
        }

        void IntializeAppoitments()
        {
            List<string> diseases = new List<string>();
            diseases.Add("Cancer Treatment");
            diseases.Add("General Check up");
            diseases.Add("Heart Surgery");
            diseases.Add("Consulting");
            diseases.Add("Eye Operation");

            Random ran = new Random();
			var year = DateTime.Now.Year;
			var month = DateTime.Now.Month;

			ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>();

            for (int i = 0; i < this.Patients.Count; i++)
            {
                Patient patient = this.Patients[i];
				Appointment appointment = new Appointment();

                appointment.Subject = diseases[ran.Next(0, diseases.Count-1)];

                DateTime startTime;

                do
                {
					startTime = new DateTime(year, month, ran.Next(1,28), ran.Next(1, 24), ran.Next(0, 30) % 30 == 0 ? 0 : 30, 0);
                } while (CheckHasAppoinment(startTime));

                Random random = new Random();
                appointment.StartTime = startTime;
                appointment.EndTime = startTime.AddMinutes(30);
                appointment.EventColor= Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                appointments.Add(appointment);
            }

            this.Appointments = appointments;
        }

        bool CheckHasAppoinment(DateTime dateTime)
        {
            return false;
        }

        ObservableCollection<Observation> GetRandomObservations()
        {
            ObservableCollection<Observation> observations = new ObservableCollection<Observation>();
            int Value = 0;
            int BP=0, Temp=0, RR=0, HR=0;
            Random ran = new Random();

            DateTime time = DateTime.Now;

            for (int i = 0; i < 70; i++)
            {
                Observation observation = new Observation();
                if (Value == 0)
                {
                    BP = ran.Next(30, 90);
                    observation.BP = BP;
                    Temp = ran.Next(50, 90);
                    observation.Temp = Temp;
                    RR = ran.Next(12, 40);
                    observation.RR = RR;
                    HR = ran.Next(30, 90);
                    observation.HR = HR;
                    Value++;
                }
                else if(i%5==0)
                {

                    BP = ran.Next(30, 90);
                    observation.BP = BP;
                    Temp = ran.Next(50, 90);
                    observation.Temp = Temp;
                    RR = ran.Next(12, 40);
                    observation.RR = RR;
                    HR = ran.Next(30, 90);
                    observation.HR = HR;
                }
                else 
                {
                        observation.BP =  BP;
                        observation.Temp =  Temp;
                        observation.RR =  RR;
                        observation.HR = HR;
                    Value = 0;
                }
                observation.DateTime = time.AddSeconds(i);
                observations.Add(observation);
            }

            return observations;
        }
    }
}
