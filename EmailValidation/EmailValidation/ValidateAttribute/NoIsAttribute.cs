﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmailValidate.ValidateAttribute
{
    public class NoIsAttribute : ValidationAttribute, IClientValidatable
    {
        /// <summary> 

        /// 禁止輸入的值 

        /// </summary> 

        public string[] Input { get; set; }

        //因為此驗證不可能不輸入要禁止的值，所以利用建構式來強迫輸入 

        public NoIsAttribute(string input)

        {

            //this.Input = input;

            //檢查是否有包含分隔符號
            if (input.IndexOf(",") > -1)
                //有的話就切吧
                this.Input = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            else
                //沒有的話就新增一個字串陣列塞過去
                this.Input = new string[] { input };
        }

        public override bool IsValid(object value)

        {

            //要不要輸入與此驗證無關
            if (value == null)
                return true;

            //如果輸入的值是字串才做判斷
            if (value is string)
            {
                //輸入值與欄位值相同就報錯
                if (Input.Contains(value.ToString()))
                    return false;
            }
            return true;
            ////要不要輸入與此驗證無關 

            //if (value == null)

            //    return true;


            ////如果輸入的值是字串才做判斷 

            //if (value is string)

            //{

            //    string[] Inputs = Input.Split(',');

            //    foreach (var item in Inputs)

            //    {

            //        //輸入值與欄位值相同就報錯 

            //        if (value.ToString().Contains(item.ToString()))

            //            return false;

            //    }

            //}

            //return true;

        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)

        {

            System.Web.Mvc.ModelClientValidationRule rule = new ModelClientValidationRule

            {

                ValidationType = "nois",

                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())

            };

            //此參數一定要是小寫！ 

            //rule.ValidationParameters["input"] = Input;
            rule.ValidationParameters["input"] = string.Join(",", Input);

            yield return rule;

        }

    }
}