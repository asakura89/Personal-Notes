using System;

namespace NilaiTetap {
    class Program {
        const bool bundar = true;

        readonly bool topiSaya = bundar;
        readonly bool bukanTopiSaya;

        public Program() { // ← ini constructor\
            bukanTopiSaya = bundar == false;

            // bundar = false;
            // ^ compile-time error

            Console.WriteLine($"Apakah topi saya bundar? {topiSaya}");
            Console.WriteLine($"Bagaimana dengan bukan topi saya, apakah juga bundar? {bukanTopiSaya}");

            Console.ReadLine();
        }

        static void Main(string[] args) {
            var program = new Program();
        }
    }
}
