using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace chatbot.bot.Common
{
    public class OptionButtonDialog
    {
        public static async Task<DialogTurnResult> ShowOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken, string name)
        {
            var option = await stepContext.PromptAsync(
                nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(name + " Ahora dime ¿Qué nivel de experiencia tienes sobre el desarrollo UX?"),
                    Choices = ChoiceFactory.ToChoices(new List<string> {"Junior", "Semi-Senior", "Senior" }),
                    Style = ListStyle.HeroCard
                },
                cancellationToken
             );
            return option;
        }

        public static async Task<DialogTurnResult> ShowOptionsEtapa(WaterfallStepContext stepContext, CancellationToken cancellationToken, string name)
        {
            var option2 = await stepContext.PromptAsync(
                nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(" Muy bien " + name + ", ahora, en tu proyecto ¿En qué etapa de desarrollo te encuentras?"),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Investigación", "Definición", "Ideación/Generación", "Evaluación"}),
                    Style = ListStyle.HeroCard

                },
                cancellationToken
             );

            return option2;
        }

        public static async Task<DialogTurnResult> ShowOptionsTipo(WaterfallStepContext stepContext, CancellationToken cancellationToken, string name)
        {
            var option3 = await stepContext.PromptAsync(
                nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(" Ahora " + name + ", ¿Qué tipo de herramienta buscas?"),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Cuantitativo", "Cualitativo"}),
                    Style = ListStyle.HeroCard
                },
                cancellationToken
             );
            return option3;
        }

        public static async Task<DialogTurnResult> ShowOptionsDifi(WaterfallStepContext stepContext, CancellationToken cancellationToken, string name)
        {
            var option4 = await stepContext.PromptAsync(
                nameof(ChoicePrompt),
                new PromptOptions
                {
                    Prompt = MessageFactory.Text(" Por último " + name + ", ¿Qué nivel de dificultad buscas?"),
                    Choices = ChoiceFactory.ToChoices(new List<string> { "Baja", "Media", "Alta" }),
                    Style = ListStyle.HeroCard
                },
                cancellationToken
             );
            return option4;
        }

    }
}
