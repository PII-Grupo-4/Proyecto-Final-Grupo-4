using System.IO;

namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ver partida jugada".
    /// </summary>
    public class SeeGameSummariesHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SeeGameSummariesHandler"/>. Esta clase procesa el mensaje "ver partida jugada".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SeeGameSummariesHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"ver partidas jugadas", "ver partidas"};
        }

        /// <summary>
        /// Procesa el mensaje "ver partidas jugadas" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            try
            {
                User user = UserRegister.GetUser(message.id);

                if (user.getStatus() != "start")
                {
                    // Estado de user incorrecto
                    response = $"Comando incorrecto. Estado del usuario = {user.getStatus()}";
                    return;
                }
                else
                {
                    // Se leen los juegos jugados
                    response = File.ReadAllText("GameSummaries.txt");
                }
            }
            catch
            {
                response = "Sucedió un error.";
            }
        }
    }
}