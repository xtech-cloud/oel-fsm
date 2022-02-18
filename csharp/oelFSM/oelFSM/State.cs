using System.Collections.Generic;

namespace XTC.oelFSM
{
    /// <summary>
    /// 状态
    /// </summary>
    public class State
    {
        /// <summary>
        /// 状态名称
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// 默认的完成事件
        /// </summary>
        public Event onFinish { get; private set; }

        internal Machine machine { get; set; }

        internal State(Machine _machine, string _name)
        {
            name = _name;
            machine = _machine;
            onFinish = new Event("FINISH");
        }

        protected State()
        {

        }

        private List<Action> actions = new List<Action>();


        /// <summary>
        /// 新建行为
        /// </summary>
        /// <returns>
        /// 新的行为
        /// </returns>
        public T NewAction<T>() where T : Action, new()
        {
            T action = new T();
            action.bindState(this);
            actions.Add(action);
            return action;
        }

        public string ToTreeString()
        {
            string tree = "";
            foreach (var acton in actions)
            {
                tree += string.Format("  - {0}\n", acton.GetType().ToString());
            }
            return tree;
        }

        internal void doEnter()
        {
            actions.ForEach((_item) =>
            {
                _item.doEnter();
            });
        }

        internal void doExit()
        {
            actions.ForEach((_item) =>
            {
                _item.doExit();
            });
        }

        internal void doUpdate()
        {
            int finishCount = 0;
            actions.ForEach((_item) =>
            {
                if (Action.Status.RUN == _item.status)
                {
                    _item.doUpdate();
                }
                else if (Action.Status.FINISH == _item.status)
                {
                    finishCount += 1;
                }
            });

            //all actions finish
            if (actions.Count == finishCount)
            {
                if (null != onFinish.state)
                {
                    machine.switchState(onFinish.state);
                }
            }
        }
    }

}//namespace
