using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FT.Commons.SkinProcessor
{
    public class IrisSkin2Proccssor
    {
        public static Sunisoft.IrisSkin.SkinEngine se = null;

        private static string defaultSkin = "FT.Commons.SkinProcessor.Skins." + SkinType.MacOS + ".ssk";

        private IrisSkin2Proccssor()
        {
        }

        /// <summary>
        /// Initializes the <see cref="IrisSkin2Proccssor"/> class.
        /// </summary>
        public static void InitSkinEngine()
        {
             System.Reflection.Assembly thisDll = System.Reflection.Assembly.GetExecutingAssembly();
             if (se == null)
             {
                 se = new Sunisoft.IrisSkin.SkinEngine(Application.OpenForms[0], thisDll.GetManifestResourceStream(defaultSkin));
                 se.SkinAllForm = true;
                 se.SkinDialogs = true;
                 se.Active = true;
             }
             else
             {
                 se.SkinStream = thisDll.GetManifestResourceStream(defaultSkin);
                 se.SkinAllForm = true;
                 se.SkinDialogs = true;
                 se.Active = true;
             }
        }

        /// <summary>
        /// Applies the skin.
        /// </summary>
        /// <param name="form">The form.</param>
        public static void ApplySkin(Form form)
        {
            if(se!=null)
            {
                se.AddForm(form);
		        //se.Active = true;
            }
        }
        /// <summary>
        /// Applies the skin.
        /// </summary>
        /// <param name="form">The form.</param>
        public static void DeleteSkin(Form form)
        {
            if (se != null)
            {
               // se.Active = false;
                se.RemoveForm(form,false);
               // se.Active = true;
            }
        }
        /// <summary>
        /// Changes the skin.
        /// </summary>
        /// <param name="type">The type.</param>
        public static void ChangeSkin(String type)
        {
            ChangeSkin((SkinType)Enum.Parse(typeof(SkinType),type,true));
        }
        /// <summary>
        /// Changes the skin.
        /// </summary>
        /// <param name="st">The st.</param>
        public static void ChangeSkin(SkinType st)
        {
            System.Reflection.Assembly thisDll = System.Reflection.Assembly.GetExecutingAssembly();
            if (se == null)
            {
                se = new Sunisoft.IrisSkin.SkinEngine(Application.OpenForms[0], thisDll.GetManifestResourceStream("Fm.Src.Common.SkinProcessor.Skins." + st.ToString() + ".ssk"));
                se.Active = true;
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    se.AddForm(Application.OpenForms[i]);
                }

            }
            else
            {
                se.SkinStream = thisDll.GetManifestResourceStream("FT.Commons.SkinProcessor.Skins." + st.ToString() + ".ssk");
                se.Active = true;
            }
        }
        public static void RemoveSkin()
        {
            if (se == null)
            {
                return;
            }
            else
            {
                se.Active = false;
            }
        } 

    }
}
