using chatbot.bot.Common;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace chatbot.bot.Dialogs
{
    public class RootDialog: ComponentDialog
    {
        String name;
        String option;
        String option2;
        String option3;
        String option4;
        public RootDialog()
        {
            var waterfallStep = new WaterfallStep[]
            {
                setName,
                showOptionsExp,
                confirmOptionExp,
                showOptionsEtapa,
                confirmOptionEtapa,
                showOptionsTipo,
                confirmOptionTipo,
                ShowOptionsDifi,
                confirmOptionsDifi,
                showInformation
            };

            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallStep));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
            AddDialog(new ChoicePrompt(nameof(ChoicePrompt)));
        }


        private async Task<DialogTurnResult> setName(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("¡Hola! soy Bottie, y estoy aquí para orientarte sobre diferentes herramientas que te ayudarán el desarrollo tu proyecto UX ", cancellationToken: cancellationToken);
            await Task.Delay(1000);
            return await stepContext.PromptAsync(
                nameof(TextPrompt),
                new PromptOptions { Prompt = MessageFactory.Text("Para empezar cuéntame, ¿Cuál es tu nombre? ")}, cancellationToken
             );
        }

        private async Task<DialogTurnResult> showOptionsExp(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
             this.name = stepContext.Context.Activity.Text;
            return await OptionButtonDialog.ShowOptions(stepContext, cancellationToken, name);
        }

        private async Task<DialogTurnResult> confirmOptionExp(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            this.option = stepContext.Context.Activity.Text;
            return await stepContext.NextAsync(cancellationToken: cancellationToken); 
        }

        private async Task<DialogTurnResult> showOptionsEtapa(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {  
            return await OptionButtonDialog.ShowOptionsEtapa(stepContext, cancellationToken, name);
        }

        private async Task<DialogTurnResult> confirmOptionEtapa(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
           this.option2 = stepContext.Context.Activity.Text;
            return await stepContext.NextAsync(cancellationToken: cancellationToken);
        }


        private async Task<DialogTurnResult> showOptionsTipo(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await OptionButtonDialog.ShowOptionsTipo(stepContext, cancellationToken, name);
        }

        private async Task<DialogTurnResult> confirmOptionTipo(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
           this.option3 = stepContext.Context.Activity.Text;
            return await stepContext.NextAsync(cancellationToken: cancellationToken);
        }

        private async Task<DialogTurnResult> ShowOptionsDifi(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await OptionButtonDialog.ShowOptionsDifi(stepContext, cancellationToken, name);
        }

        private async Task<DialogTurnResult> confirmOptionsDifi(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            this.option4 = stepContext.Context.Activity.Text;
            return await stepContext.NextAsync(cancellationToken: cancellationToken);
        }

        private async Task<DialogTurnResult> showInformation(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {

            await Task.Delay(1000);
            await stepContext.Context.SendActivityAsync("Maravilloso, con toda esa información he encontrado estas herramientas junto a Técnicas y/o Etapas que te pueden servir con tu proyecto.");

            if (this.option2 == "Definición" && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Junior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Problem Statement  https://medium.com/eightshapes-llc/how-to-build-a-problem-statement-d1f21713720b");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Definición" || this.option2 == "Investigación" || this.option2 == "Evaluación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Junior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("User Persona: https://en.99designs.com.mx/blog/business/how-to-create-user-personas/ ");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Definición" || this.option2 == "Investigación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Junior" && this.option4 == "Media")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Perfil de usuario: https://www.designthinking.es/inicio/herramienta.php?id=6&fase=idea#:~:text=La%20creaci%C3%B3n%20de%20perfiles%20de,dirigida%20la%20soluci%C3%B3n%20a%20definir.");
                await Task.Delay(1000);
            }

            if (this.option2 == "Investigación" && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Semi-Senior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Observación contextual: https://medium.com/@andrewdjandrw/qu%C3%A9-es-la-observaci%C3%B3n-contextual-12cf24998bda  ");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Investigación" || this.option2 == "Evaluación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Junior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Observación: http://materials.cv.uoc.edu/cdocent/design_toolkit/es/pdf/observacion.pdf");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Definición" || this.option2 == "Investigación" || this.option2 == "Evaluación" || this.option2 == "Ideación/Generación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Senior" && this.option4 == "Media")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Modelo Kano: https://es.wikipedia.org/wiki/Modelo_de_Kano#:~:text=El%20modelo%20Kano%20es%20una,del%20cliente%20en%20cinco%20categor%C3%ADas. ");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Definición" || this.option2 == "Investigación" || this.option2 == "Ideación/Generación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Junior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Mapa de empatía: https://medium.com/idachile/mapa-de-empat%C3%ADa-c%C3%B3mo-ejecutarlo-y-entregarlo-efectivamente-f101081824c7 ");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Investigación" || this.option2 == "Evaluación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo")  && this.option == "Senior" && this.option4 == "Alta")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Focus Groups: https://www.nngroup.com/articles/focus-groups/ ");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Investigación" || this.option2 == "Evaluación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Senior" && this.option4 == "Media")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Evaluación heurística: https://tercetocomunicacion.es/evaluacion-heuristica-en-diseno-web-ux/ ,  https://www.nngroup.com/articles/ten-usability-heuristics/");
                await Task.Delay(1000);

            }

            if ((this.option2 == "Definición" || this.option2 == "Investigación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Junior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Escenarios: https://medium.com/@FedeAlvarezSm/escenario-en-ux-las-situaciones-en-las-que-se-usar%C3%A1-tu-producto-6425dc2f568b ");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Evaluación" || this.option2 == "Investigación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Senior" && this.option4 == "Alta")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Entrevistas con usuarios: https://www.nngroup.com/articles/user-interviews/");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Evaluación" || this.option2 == "Investigación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Semi-Senior" && this.option4 == "Alta")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Encuestas: https://uxplanet.org/tips-b%C3%A1sicos-para-dise%C3%B1ar-encuestas-y-cuestionarios-232aff97ef69");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Evaluación" || this.option2 == "Investigación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Semi-Senior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Diarios de usuarios: https://www.nngroup.com/articles/diary-studies/");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Definición" || this.option2 == "Evaluación" || this.option2 == "Ideación/Generación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Semi-Senior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Diagrama de flujos https://uxplanet.org/tips-and-tricks-for-making-a-ux-flowchart-bf48e42da869");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Evaluación" || this.option2 == "Investigación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Senior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Cuestionarios: https://uxplanet.org/tips-b%C3%A1sicos-para-dise%C3%B1ar-encuestas-y-cuestionarios-232aff97ef69 ");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Definición" || this.option2 == "Investigación" || this.option2 == "Ideación/Generación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Junior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Card Sorting:  https://uxplanet.org/improving-information-architecture-through-card-sorting-730a66b7bdda");
                await Task.Delay(1000);
            }

            if (this.option2 == "Investigación" && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Semi-Senior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Benchmarking: https://www.nngroup.com/articles/product-ux-benchmarks/");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Definición" || this.option2 == "Ideación/Generación")  && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Senior" && this.option4 == "Alta")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Arquitectura de la información https://blog.acantu.com/que-es-arquitectura-informacion/");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Evaluación" || this.option2 == "Investigación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Senior" && this.option4 == "Media")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Affinity Diagram: https://uxdict.io/design-thinking-methods-affinity-diagrams-357bd8671ad4");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Definición" || this.option2 == "Evaluación")  && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Semi-Senior" && this.option4 == "Media")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("User Journey https://www.nngroup.com/articles/customer-journey-mapping/");
                await Task.Delay(1000);
            }

            if (this.option2 == "Evaluación" && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Senior" && this.option4 == "Media")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Tree Testing https://www.torresburriel.com/weblog/2017/05/11/el-tree-test-una-forma-facil-e-iterativa-de-probar-las-categorias-y-las-etiquetas-de-un-menu/");
                await Task.Delay(1000);
            }

            if (this.option2 == "Evaluación" && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Senior" && this.option4 == "Alta")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Test con usuarios https://www.hotjar.com/usability-testing/");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Definición" || this.option2 == "Evaluación" || this.option2 == "Ideación/Generación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Semi-Senior" && this.option4 == "Media")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Storyboard https://www.nngroup.com/articles/storyboards-visualize-ideas/");
                await Task.Delay(1000);
            }

            if ((this.option2 == "Definición" || this.option2 == "Evaluación" || this.option2 == "Ideación/Generación") && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Senior" && this.option4 == "Alta")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Prototipado https://www.nngroup.com/articles/ux-prototype-hi-lo-fidelity/", cancellationToken: cancellationToken);
            }

            if (this.option2 == "Ideación/Generación" && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Junior" && this.option4 == "Media")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Wireframing https://uxplanet.org/ux-wireframing-bedrock-of-interface-usability-7e9c76bd804d");
                await Task.Delay(1000);
            }

            if (this.option2 == "Ideación/Generación" && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Senior" && this.option4 == "Media")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Diseño atómico https://bradfrost.com/blog/post/atomic-web-design/#atoms");
                await Task.Delay(1000);
            }

            if (this.option2 == "Ideación/Generación" && (this.option3 == "Cuantitativo" || this.option3 == "Cualitativo") && this.option == "Junior" && this.option4 == "Baja")
            {
                await Task.Delay(1000);
                await stepContext.Context.SendActivityAsync("Versionado https://semver.org/", cancellationToken: cancellationToken);
                await Task.Delay(1000);
            }

            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }







    }
}
