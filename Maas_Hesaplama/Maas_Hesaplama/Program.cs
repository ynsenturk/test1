using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Maas_Hesaplama
{
    public class Program
    {
        double netMaas, brutMaas, kesintiler, vergiler;
        double netMaasMin, netMaasMax;
         
        int sayac = 0;
        Random rastgele = new Random();
        public static void Main(string[] args)
        {
            double net;
            Program maas = new Program();
            
            Console.WriteLine("Net maasinizi giriniz: ");
            net = Convert.ToDouble( Console.ReadLine());
            Console.WriteLine("Brut maasiniz: "+ maas.BrutMaasHesapla(net));

           

            Console.ReadLine();
        }
        public double NetMaasHesapla(double brutMaas)
        {
            vergiler = brutMaas * 0.2;
            kesintiler = brutMaas * 0.1;
            netMaas = brutMaas - vergiler - kesintiler;
            return netMaas;
        }
        public double BrutMaasHesapla(double netMaas)
        {
            sayac++;

        
            if (sayac==1)
            {
                netMaasMin = netMaas;
                netMaasMax = netMaas + netMaas * 0.1;
                netMaas = rastgele.Next(Convert.ToInt32(netMaasMin), Convert.ToInt32(netMaasMax));
            }

            brutMaas = netMaas * 1.5;
            double netMaasTahmin = NetMaasHesapla(brutMaas);
            double yanilmaPayi = netMaas*0.05;
            if (netMaasTahmin-yanilmaPayi > netMaas)
            {
                if (sayac>1)
                {
                    netMaasMin = netMaas;

                }


                netMaas = rastgele.Next(Convert.ToInt32(netMaasMin), Convert.ToInt32(netMaasMax));
                
                return BrutMaasHesapla(netMaas);
               
            }
            
            else if (netMaasTahmin+yanilmaPayi<netMaas)
            {
                netMaasMax = netMaas + netMaas * 0.1;
                netMaas = rastgele.Next(Convert.ToInt32(netMaasMin), Convert.ToInt32(netMaasMax));
                return BrutMaasHesapla(netMaas);
            }
            return brutMaas;
           
        }
        

    }
}


