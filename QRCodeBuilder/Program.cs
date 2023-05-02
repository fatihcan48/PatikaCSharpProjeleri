using IronBarCode;

namespace QRCodeBuilder
{
    public class Program
    {
        static void Main(string[] args)
        {
            // QRCode üretimi ;
            var path = Barcode.CreateQRCodeOrBarcode("QRCode.jpeg", @"https://github.com/fatihcan48/PatikaCSharpProjeleri",
                BarcodeWriterEncoding.QRCode);
            
            // QRCode Okuma ;
            Barcode.ReadBarcodeImages(path);

            // Farklı barcode tipleri ;

            var path2 = Barcode.CreateQRCodeOrBarcode("Barcode.jpeg", @"https://github.com/fatihcan48/PatikaCSharpProjeleri/tree/master/QRCodeBuilder",
                BarcodeWriterEncoding.Aztec);

            Barcode.ReadBarcodeImages(path2);

            var path3 = Barcode.CreateQRCodeOrBarcode("Welcome.jpeg", "Barkod olusturucuya hosgeldiniz!",
               BarcodeWriterEncoding.Code128);

            Barcode.ReadBarcodeImages(path3);


            Console.ReadKey();
        }
    }

    public class Barcode
    {
        public static string CreateQRCodeOrBarcode(string fileName, string content,
            BarcodeWriterEncoding barcodeWriter)
        {
            var myBarcode = BarcodeWriter.CreateBarcode(content, barcodeWriter);

            var path = @"C:\Users\fatih\Desktop\Kodluyoruz\PatikaCSharpProjeleri\QRCodeBuilder\bin\Debug\net6.0\QRCodesAndBarcodes\";

            myBarcode.ResizeTo(1000, 400);

            myBarcode.SaveAsImage(path+fileName);

            return fileName;
        }

        public static void ReadBarcodeImages(string fileName)
        {
            string path = @"C:\Users\fatih\Desktop\Kodluyoruz\PatikaCSharpProjeleri\QRCodeBuilder\bin\Debug\net6.0\QRCodesAndBarcodes\";
            var resultFromFile = BarcodeReader.Read(path + fileName);

            if (resultFromFile.Values()==null)
            {
                Console.WriteLine("Belirtilen adreste girilen barcode/QRCode image dosyası bulunmamaktadır.");
            }

            foreach (var item in resultFromFile)
            {
                Console.WriteLine(item);
            }
        }
    }
}