using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negru_Luminita_Lab7
{
    public class ValidationBehaviour : Behavior<Editor>
    {
        protected override void OnAttachedTo(Editor editor)
        {
            editor.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(editor);
        }

        protected override void OnDetachingFrom(Editor editor)
        {
            editor.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(editor);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var editor = (Editor)sender;
            editor.BackgroundColor = string.IsNullOrEmpty(args.NewTextValue) ? Color.FromRgba("#AA4A44") : Color.FromRgba("#FFFFFF");
        }
    }

}
