using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SalesChecker
{
    class ReadFile
    {
        private StreamReader sr = new StreamReader("Data\\test.txt");
        private DirectoryInfo di;
        private List<Record> records = new List<Record>();
        

            
            public void ReadMeBitch()
        {
        
            HitAndRun();
            Topchik();
            PizdaImNaHUI();
            Console.ReadKey();
           
        }

        public void HitAndRun()
        {
         
           
            
            string [] lines = File.ReadAllLines("Data\\test.txt");
            foreach(string stroka in lines)
            {
                int mode = 1;
                string email = "";
                string date = "";
                string partner_id = "";
                char[] line_chars = stroka.ToCharArray() ;
                foreach(char separator in line_chars)
                {
                    
                    if (separator != ';')
                    {
                        if (mode == 1)
                        {
                            email += separator;
                        }
                        else if (mode == 2)
                        {
                            date += separator;
                        }
                        else if (mode == 3)
                        {
                            partner_id += separator;

                        }
                        //else if (mode == 4)
                        //    mode = 1;
                    }
                    else
                    {

                        mode++;

                    }
                    
                }
                Record record = new Record();
                record.email = email;
                record.date = Convert.ToDateTime(date);
                record.partner_id = partner_id;
                records.Add(record);
            }
        }

        public void Topchik()
        {
            foreach(Record record in records)
            {
                Console.WriteLine(record.email+" "+record.date+" "+record.partner_id);
            }
        }
        public void PizdaImNaHUI()
        {
            int email_ak_count = 0;
            int email_ap_count = 0;
            int email_sk_count = 0;
            string[] ak_emails = new string[25];
            string[] sk_emails = new string[25];
            string[] ap_emails = new string[25];

            foreach (Record record in records)
            {
                if (record.partner_id == "ak")
                {

                    ak_emails[email_ak_count] = record.email;
                    email_ak_count++;

                }
                else if (record.partner_id == "sk")
                {

                    sk_emails[email_sk_count] = record.email;
                    email_sk_count++;
                }
                else if (record.partner_id == "ap")
                {
                    ap_emails[email_ap_count] = record.email;
                    email_ap_count++;
                }
            }
            
                Console.WriteLine("AK:" + email_ak_count);
            
            {
                Console.WriteLine(ak_emails);
            }
                Console.WriteLine("AP:" + email_ap_count);
                Console.WriteLine("SK:" + email_sk_count);
            
        }
    }
}
