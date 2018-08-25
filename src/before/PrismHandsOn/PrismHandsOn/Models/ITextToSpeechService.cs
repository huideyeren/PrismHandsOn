using System;
namespace PrismHandsOn.Models
{
  public interface ITextToSpeechService
  {
    void Speak(string Text);
  }
}
