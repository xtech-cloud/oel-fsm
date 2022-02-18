using System.Collections.Generic;

namespace XTC.oelFSM
{
    /// <summary>
    /// 状态机
    /// </summary>
    public class Machine
    {
        /// <summary>
        /// 启动事件
        /// </summary>
        public Event onStartup { get; private set; }

        // 状态列表
        private List<State> status = new List<State>();

        // 命令表
        private Dictionary<string, Command> commands = new Dictionary<string, Command>();

        // 参数表
        private Dictionary<string, Parameter> parameters = new Dictionary<string, Parameter>();

        // 当前活动的状态
        private State activeState_ { get; set; }

        public Machine()
        {
            onStartup = new Event("STARTUP");
        }

        /// <summary>
        /// 新建一个状态
        /// </summary>
        /// <param name="_name">状态名</param>
        /// <returns>
        /// 新的状态
        /// </returns>
        public State NewState(string _name)
        {
            State state = new State(this, _name);
            status.Add(state);
            return state;
        }

        /// <summary>
        /// 删除一个状态
        /// </summary>
        /// <param name="_state">要删除的状态</param>
        public void DeleteState(State _state)
        {
            if (!status.Contains(_state))
                return;
            status.Remove(_state);
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="_name">参数名</param>
        /// <param name="_parameter">参数值</param>
        public void SetParameter(string _name, Parameter _parameter)
        {
            parameters[_name] = _parameter;
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="_name">参数名</param>
        /// <returns>
        /// 参数值
        /// </returns>
        public Parameter GetParameter(string _name)
        {
            Parameter parameter;
            parameters.TryGetValue(_name, out parameter);
            return parameter;
        }


        public Command NewCommand(string _name)
        {
            if (commands.ContainsKey(_name))
                return null;
            Command command = new Command(_name);
            commands[_name] = command;
            return command;
        }

        public void DeleteCommand(Command _command)
        {
            if (!commands.ContainsKey(_command.Name))
                return;
            commands.Remove(_command.Name);
        }

        public void InvokeCommand(string _command)
        {
            Command command;
            if (!commands.TryGetValue(_command, out command))
                return;
            if (null == command.state)
                return;
            switchState(command.state);
        }

        /// <summary>
        /// 运行状态机
        /// </summary>
        public void Run()
        {
            activeState_ = onStartup.state;
            if (null == activeState_)
            {
                throw new System.ArgumentNullException("None state is active");
            }
            activeState_.doEnter();
        }

        /// <summary>
        /// 状态机更新
        /// </summary>
        public void Update()
        {
            if (null == activeState_)
                return;
            activeState_.doUpdate();
        }

        // 打印树状字符
        public string ToTreeString()
        {
            string tree = "\n";
            foreach (var state in status)
            {
                tree += string.Format("+ {0}\n", state.name);
                tree += state.ToTreeString();
            }
            return tree;
        }

        /// <summary>
        /// 切花状态
        /// </summary>
        /// <param name="_state">目标状态</param>
        internal void switchState(State _state)
        {
            if (null == _state)
                return;
            if (null != activeState_)
                activeState_.doExit();
            activeState_ = _state;
            activeState_.doEnter();
        }
    }
}
