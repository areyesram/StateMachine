using System.Linq;

namespace StateMachine
{
    internal class DFA
    {
        internal DFA()
        {
            CurrentState = State.Creada;
        }

        internal bool GoNext(Action action)
        {
            var trans = TransitionMatrix.FirstOrDefault(o => o.CurrentState == CurrentState && o.Action == action);
            if (trans == null) return false;
            CurrentState = trans.NewState;
            return true;
        }

        internal State CurrentState { get; private set; }

        internal static Transition[] TransitionMatrix =
        {
            new Transition(State.Creada, Action.Editar, State.Creada),
            new Transition(State.Creada, Action.Enviar, State.PorRevisar),
            new Transition(State.PorRevisar, Action.Enviar, State.PorAutorizar),
            new Transition(State.PorAutorizar, Action.Autorizar, State.PorContabilizar),
            new Transition(State.PorContabilizar, Action.Contabilizar, State.Finalizada),
            new Transition(State.PorRevisar, Action.Devolver, State.Creada),
            new Transition(State.PorAutorizar, Action.Rechazar, State.Rechazada),
            new Transition(State.Rechazada, Action.Solicitar, State.Reenviada),
            new Transition(State.Reenviada, Action.Autorizar, State.PorContabilizar),
            new Transition(State.Reenviada, Action.Rechazar, State.RechazadaFinal),
            new Transition(State.Rechazada, Action.Cerrar, State.RechazadaFinal),
            new Transition(State.Reenviada, Action.Cerrar, State.RechazadaFinal)
        };

        internal class Transition
        {
            internal State CurrentState { get; set; }
            internal Action Action { get; set; }
            internal State NewState { get; set; }

            public Transition(State currentState, Action action, State newState)
            {
                CurrentState = currentState;
                Action = action;
                NewState = newState;
            }
        }

        internal enum State
        {
            Creada,
            PorRevisar,
            PorAutorizar,
            PorContabilizar,
            Finalizada,
            Rechazada,
            Reenviada,
            RechazadaFinal
        }

        internal enum Action
        {
            Editar,
            Enviar,
            Autorizar,
            Contabilizar,
            Devolver,
            Rechazar,
            Solicitar,
            Cerrar
        }
    }
}