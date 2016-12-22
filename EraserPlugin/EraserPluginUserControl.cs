using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oop.Tasks.Paint.Interface;

namespace EraserPlugin
{
    public partial class EraserPluginUserControl : UserControl
    {
        private IPaintApplicationContext applicationContext = null;
        public EraserPluginUserControl(IPaintApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает ширину ластика.
        /// </summary>
        /// <returns>Возвращает целочисленное значение от 1 до 20.</returns>
        internal int GetEraserWidth()
        {
            return CtrlTBWidth.Value;
        }

        /// <summary>
        /// Возвращает кисть с цветом заднего фона.
        /// </summary>
        /// <returns>Возвращает экземпляр кисти.</returns>
        internal Brush GetEraser()
        {
            return new SolidBrush(applicationContext.BackgroundColor);
        }

        /// <summary>
        /// Возвращает карандаш для зарисовки пустых мест.
        /// </summary>
        /// <returns></returns>
        internal Pen GetHelpPen()
        {
            return new Pen(applicationContext.BackgroundColor, CtrlTBWidth.Value);
        }
    }
}
