using System;

namespace ValidadorCPF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o seu cpf: ");
            string cpf = Console.ReadLine();
            if(validaCpf(cpf)) {
                Console.WriteLine("CPF VÁLIDO");
            } else {
                Console.WriteLine("CPF INVÁLIDO");
            }
        }
        /// <summary>
        /// A função validaCpf capta o CPF do usuário e valida.
        /// </summary>
        /// <param name="cpfUsuario">Informe o número do CPF</param>
        /// <returns>A função retorna true caso o CPF seja válido e false caso seja inválido.</returns>
        static bool validaCpf(string cpfUsuario){
            int[] v1 = {10, 9, 8, 7, 6, 5, 4, 3, 2}; //Primeiro validador
            int[] v2 = {11, 10, 9, 8, 7, 6, 5, 4, 3, 2}; //Segundo validador
            bool retorno = true;
            string cpfCalculo;
            int r1 = 0; // Variável pra guardar o primeiro número validador
            int r2 = 0; // Variável pra guardar o segundo número validador

            cpfCalculo = cpfUsuario.Substring(0, cpfUsuario.Length-2); // Cópia do CPF informado pelo usuário sem os últimos dois dígitos
            
            for(int i = 0; i < cpfCalculo.Length; i++) { 
                r1 += Int32.Parse(cpfCalculo[i].ToString())*v1[i];
            }               

            if(r1 % 11 < 2) {
                cpfCalculo += "0";
            } else {
                cpfCalculo += (11 - (r1%11)).ToString();
            }

            for(int i = 0; i < cpfCalculo.Length; i++) {
                r2 += Int32.Parse(cpfCalculo[i].ToString())*v2[i];
            }               

            if(r2 % 11 < 2) {
                cpfCalculo += "0";
            } else {
                cpfCalculo += (11 - (r2%11)).ToString();
            }

            if(cpfCalculo != cpfUsuario) {
                retorno = false;
            }

            return retorno;
        }

    }
}
