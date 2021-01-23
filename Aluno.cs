namespace Revisao
{
    public class Aluno
    {
        private string nome;
        private decimal? nota;
        
        // CONSTRUCTORS
        public Aluno() {}
        public Aluno(string nome, decimal? nota){
            this.nome = nome;
            this.nota = nota;
        }

        // GETTERS AND SETTERS
        public string getNome() {
            return this.nome;
        }

        public void setNome(string nome) {
            this.nome = nome;
        }

        public decimal? getNota() {
            return this.nota;
        }

        public void setNota(decimal? nota) {
            this.nota = nota;
        }

    }
}