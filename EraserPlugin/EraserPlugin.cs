using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oop.Tasks.Paint.Interface;
using System.Drawing;
using System.Windows.Forms;

namespace EraserPlugin
{
    // 8.	Ластик с возможностью выбора его размера. Поведение инструмента должно быть как в Microsoft Paint.
    [PluginForLoad(true)]
    public class EraserPlugin : IToolPaintPlugin
    {
        #region Поля

        /// <summary>
        /// Контекст плагина?
        /// </summary>
        private IPaintPluginContext pluginContext = null;

        /// <summary>
        /// Ссылка на юзерконтрол.
        /// </summary>
        private EraserPluginUserControl optionsControl = null;

        /// <summary>
        /// Иконка инструмента.
        /// </summary>
        private Image icon = null;

        /// <summary>
        /// Курсор инструмента.
        /// </summary>
        private Cursor cursor = null;

        /// <summary>
        /// Ширина рабочей части.
        /// </summary>
        private int width;

        /// <summary>
        /// Кисть-стиралка.
        /// </summary>
        private Brush eraserMain;

        /// <summary>
        /// Карандаш-заполнитель.
        /// </summary>
        private Pen eraserFiller;

        /// <summary>
        /// Прошлое значение мыши.
        /// </summary>
        private MouseEventArgs mOld;

        /// <summary>
        /// Флаг стирания.
        /// </summary>
        private bool erasing = false;

        #endregion

        #region Методы

        #region Косметическое

        /// <summary>
        /// Возвращает название инструмента.
        /// </summary>
        public string ToolName
        {
            get { return "Ластик"; }
        }

        /// <summary>
        /// Возвращает иконку инструмента для строки доступа.
        /// </summary>
        public Image Icon
        {
            get { return icon; }
        }

        /// <summary>
        /// Возвращает название плагина, видимо, типом.
        /// </summary>
        public string Name { get { return GetType().Name; } }

        /// <summary>
        /// Возвращает название для наводимого курсора мышки.
        /// </summary>
        public string CommandName
        {
            get
            {
                return "Ластик .NET";
            }
        }

        #endregion

        #region Движения мыши

        /// <summary>
        /// Нажатие мыши, включает флаг стирания и запоминает позицию.
        /// </summary>
        /// <param name="me">Экземпляр мыши.</param>
        /// <param name="modifierKeys">Нажатые клавиши.</param>
        public void MouseDown(MouseEventArgs me, Keys modifierKeys)
        {
            mOld = me;
            erasing = true;
            eraserMain = optionsControl.GetEraser();
            eraserFiller = optionsControl.GetHelpPen();
            width = optionsControl.GetEraserWidth();
        }

        /// <summary>
        /// Отжатие мыши - снятие флага стирания, выгрузка кисти.
        /// </summary>
        /// <param name="me">Экземпляр мыши.</param>
        /// <param name="modifierKeys">Нажатые клавиши.</param>
        public void MouseUp(MouseEventArgs me, Keys modifierKeys)
        {
            erasing = false;
            eraserMain.Dispose();
        }

        /// <summary>
        /// Движение мыши.
        /// </summary>
        /// <param name="me">Экземпляр мыши.</param>
        /// <param name="modifierKeys">Нажатые клавиши.</param>
        public void MouseMove(MouseEventArgs me, Keys modifierKeys)
        {
            if (erasing)
            {
                Graphics mainGraphics = Graphics.FromImage(ApplicationContext.Image);                           //Т.к. постоянно инвалидируется
                mainGraphics.FillRectangle(eraserMain, me.X - width / 2, me.Y - width / 2, width, width);       //Ставим главные прямоугольники
                mainGraphics.DrawLine(eraserFiller, mOld.Location, me.Location);                                //Заполняем пустые места линией нужной толщины
                mOld = me;
                ApplicationContext.Invalidate();
            }
        }

        #endregion

        #region Копипастные методы

        /// <summary>
        /// Возвращает контекст приложения.
        /// </summary>
        private IPaintApplicationContext ApplicationContext
        {
            get
            {
                if (pluginContext == null)
                    return null;
                else return pluginContext.ApplicationContext;
            }
        }

        /// <summary>
        /// Перед включением плагина в виде активного.
        /// </summary>
        /// <param name="pluginContext">Контекст плагина.</param>
        public void AfterCreate(IPaintPluginContext pluginContext)
        {
            this.pluginContext = pluginContext;
            optionsControl = new EraserPluginUserControl(ApplicationContext);
            string imageDir = pluginContext.PluginDir;
            if (imageDir != null)
            {
                imageDir += @"\Images\";

                try
                {
                    cursor = new Cursor(imageDir + "cursor.cur");
                }
                catch { }
                try
                {
                    icon = Image.FromFile(imageDir + "Icon.bmp");
                }
                catch { }
            }
        }

        /// <summary>
        /// Очистка всех хвостов после деселекта.
        /// </summary>
        public void BeforeDestroy()
        {
            optionsControl.Dispose();
            optionsControl = null;
            if (icon != null)
                icon.Dispose();
            if (cursor != null)
                cursor.Dispose();
        }

        /// <summary>
        /// При выборе плагина в строке.
        /// </summary>
        /// <param name="selection">Флаг выбора.</param>
        public void Select(bool selection)
        {
            if (selection)
            {
                ApplicationContext.OptionsControl = optionsControl;
                ApplicationContext.Cursor = cursor;
            }
            else
            {
                ApplicationContext.OptionsControl = null;
                ApplicationContext.Cursor = null;
            }
        }

        /// <summary>
        /// Для нажатия кнопки Escape.
        /// </summary>
        public void Escape()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Для нажатия кнопки Enter.
        /// </summary>
        public void Enter()
        {
        }

        /// <summary>
        /// При смене цвета в палитре.
        /// </summary>
        public void ColorChange()
        {
        }

        /// <summary>
        /// При смене изображения в контексте.
        /// </summary>
        public void ImageChange()
        {
        }

        #endregion

        #endregion
    }
}
