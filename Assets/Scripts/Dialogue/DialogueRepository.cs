namespace Joserbala.DialogueSystem
{
	public class DialogueRepository
	{
		private const string DIALOGUE_FILE = "Dialogue";
		private const string XML_EXTENSION = ".xml";

		/// <summary>
		/// Obtain the dialogue number <paramref name="currentDialogue"/>.
		/// </summary>
		/// <param name="currentDialogue">The number of the dialogue.</param>
		/// <returns></returns>
		public static string[] ObtainNextDialogue(int currentDialogue)
		{
			currentDialogue++;

			var xmlDoc = DialogueDatabase.Load(DIALOGUE_FILE + currentDialogue + XML_EXTENSION);

			return DialogueXMLNavigator.GetContents(xmlDoc);
		}
	}
}