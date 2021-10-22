using Joserbala.Utils.Enums;

namespace Joserbala.DialogueSystem
{
	public class DialogueRepository
	{
		private const string DIALOGUE_FILE = "Dialogue";
		private const string XML_EXTENSION = ".xml";

		/// <summary>
		/// Obtain the dialogue number <paramref name="dialogueNumber"/>.
		/// </summary>
		/// <param name="dialogueNumber">The number of the dialogue.</param>
		/// <returns></returns>
		public static string[] ObtainDialogue(int dialogueNumber, Languages language)
		{
			var xmlDoc = DialogueDatabase.Load(DIALOGUE_FILE + dialogueNumber + XML_EXTENSION);

			return DialogueXMLNavigator.GetContents(xmlDoc, language);
		}
	}
}