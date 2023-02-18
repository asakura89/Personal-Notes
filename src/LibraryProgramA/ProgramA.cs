using System;
using LibraryKalimat;

namespace LibraryProgramA {
    class ProgramA {
        static void Main(string[] args) {
            var penampil = new PenampilKalimat();
            penampil.TampilkanKalimat("Budi");
            Console.ReadLine();
        }
    }
}
