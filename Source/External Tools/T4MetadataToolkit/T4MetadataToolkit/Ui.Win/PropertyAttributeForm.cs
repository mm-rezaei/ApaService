using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using T4MetadataToolkit.Bol;

namespace T4MetadataToolkit.Ui.Win
{
    public partial class PropertyAttributeForm : Form
    {
        #region Constructors

        private PropertyAttributeForm()
        {
            InitializeComponent();

            var list = new List<LetterType>
            {
                LetterType.None,
                LetterType.Numeral,
                LetterType.PersianLetter,
                LetterType.EnglishLetter,
                LetterType.EnglishLetter | LetterType.PersianLetter,
                LetterType.Numeral | LetterType.EnglishLetter,
                LetterType.Numeral | LetterType.PersianLetter,
                LetterType.Numeral | LetterType.EnglishLetter | LetterType.PersianLetter
            };

            comboBoxCharacterRestrictionValidationRule.DataSource = list;
        }

        #endregion

        #region Private Methods

        private void SetCharacterRestrictionValidationRule(string inAttribte)
        {
            if (inAttribte.Contains("CharacterRestrictionValidationRule"))
            {
                var parameter = inAttribte.Replace("CharacterRestrictionValidationRule(", "").Replace(")", "");

                var enums = parameter.Split('|');

                var letterType = enums.Aggregate(LetterType.None, (current, value) => current | (LetterType) Enum.Parse(typeof (LetterType), value.Replace("LetterType.", "")));

                comboBoxCharacterRestrictionValidationRule.SelectedItem = letterType;
            }
        }

        private void SetContainValidationRule(string inAttribte)
        {
            if (inAttribte.Contains("ContainValidationRule"))
            {
                var parameter = inAttribte.Replace("ContainValidationRule(", "").Replace(")", "");

                textBoxContainValidationRule.Text = parameter;
            }
        }

        private void SetPositiveValidationRule(string inAttribte)
        {
            checkBoxPositiveValidationRule.Checked = inAttribte.Contains("PositiveValidationRule");
        }

        private void SetRangeValidationRule(string inAttribte)
        {
            if (inAttribte.Contains("RangeValidationRule"))
            {
                var parameter = inAttribte.Replace("RangeValidationRule(", "").Replace(")", "");

                var rangeItem = parameter.Split(',');

                textBoxRangeValidationRuleFrom.Text = rangeItem[0];
                textBoxRangeValidationRuleTo.Text = rangeItem[1];
            }
        }

        private void SetRequiredValidationRule(string inAttribte)
        {
            checkBoxRequiredValidationRule.Checked = inAttribte.Contains("RequiredValidationRule");
        }

        private void SetStringLengthValidationRule(string inAttribte)
        {
            if (inAttribte.Contains("StringLengthValidationRule"))
            {
                var parameter = inAttribte.Replace("StringLengthValidationRule(", "").Replace(")", "");

                textBoxStringLengthValidationRule.Text = parameter;
            }
        }

        private string GetCharacterRestrictionValidationRule()
        {
            var result = "";

            var selected = ((LetterType)comboBoxCharacterRestrictionValidationRule.SelectedItem);

            if (selected != LetterType.None)
            {
                var value = "";

                if (selected.HasFlag(LetterType.Numeral))
                {
                    value += "LetterType.Numeral";
                }

                if (selected.HasFlag(LetterType.EnglishLetter))
                {
                    if (value != "")
                    {
                        value += " | ";
                    }

                    value += "LetterType.EnglishLetter";
                }

                if (selected.HasFlag(LetterType.PersianLetter))
                {
                    if (value != "")
                    {
                        value += " | ";
                    }

                    value += "LetterType.PersianLetter";
                }

                result = string.Format("[CharacterRestrictionValidationRule({0})]", value);
            }

            return result;
        }

        private string GetContainValidationRule()
        {
            var result = "";

            if (!string.IsNullOrWhiteSpace(textBoxContainValidationRule.Text))
            {
                result = string.Format("[ContainValidationRule({0})]",
                    textBoxContainValidationRule.Text.Trim());
            }

            return result;
        }

        private string GetPositiveValidationRule()
        {
            var result = "";

            if (checkBoxPositiveValidationRule.Checked)
            {
                result = "[PositiveValidationRule]";
            }

            return result;
        }

        private string GetRangeValidationRule()
        {
            var result = "";

            if (!string.IsNullOrWhiteSpace(textBoxRangeValidationRuleFrom.Text) && !string.IsNullOrWhiteSpace(textBoxRangeValidationRuleTo.Text))
            {
                result = string.Format("[RangeValidationRule({0},{1})]",
                    textBoxRangeValidationRuleFrom.Text.Trim(), textBoxRangeValidationRuleTo.Text.Trim());
            }

            return result;
        }

        private string GetRequiredValidationRule()
        {
            var result = "";

            if (checkBoxRequiredValidationRule.Checked)
            {
                result = "[RequiredValidationRule]";
            }

            return result;
        }

        private string GetStringLengthValidationRule()
        {
            var result = "";

            if (!string.IsNullOrWhiteSpace(textBoxStringLengthValidationRule.Text))
            {
                result = string.Format("[StringLengthValidationRule({0})]",
                    textBoxStringLengthValidationRule.Text.Trim());
            }

            return result;
        }

        private void SetAttribute(string inAttribute)
        {
            inAttribute = inAttribute.Replace("]", "");

            var otherAttribute = "";

            var attributes = inAttribute.Split('[').Where(p => !string.IsNullOrWhiteSpace(p));

            foreach (var attribute in attributes)
            {
                if (attribute.Contains("CharacterRestrictionValidationRule"))
                {
                    SetCharacterRestrictionValidationRule(attribute);
                }
                else if (attribute.Contains("ContainValidationRule"))
                {
                    SetContainValidationRule(attribute);
                }
                else if (attribute.Contains("PositiveValidationRule"))
                {
                    SetPositiveValidationRule(attribute);
                }
                else if (attribute.Contains("RangeValidationRule"))
                {
                    SetRangeValidationRule(attribute);
                }
                else if (attribute.Contains("RequiredValidationRule"))
                {
                    SetRequiredValidationRule(attribute);
                }
                else if (attribute.Contains("StringLengthValidationRule"))
                {
                    SetStringLengthValidationRule(attribute);
                }
                else
                {
                    otherAttribute += "[" + attribute + "]";
                }
            }

            textBoxOther.Text = otherAttribute;
        }

        private string GetAttribute()
        {
            var result = "";

            result += GetCharacterRestrictionValidationRule();
            result += GetContainValidationRule();
            result += GetPositiveValidationRule();
            result += GetRangeValidationRule();
            result += GetRequiredValidationRule();
            result += GetStringLengthValidationRule();
            result += textBoxOther.Text;

            return result;
        }

        #endregion

        #region Public Methods

        public static string GetPropertyAttribute(string inAttribute)
        {
            var result = inAttribute;

            var form = new PropertyAttributeForm();

            form.SetAttribute(inAttribute);

            if (form.ShowDialog() == DialogResult.OK)
            {
                result = form.GetAttribute();
            }

            return result;
        }

        #endregion
    }
}
