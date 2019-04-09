using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02Distributed.Models
{

    //Code obtained from https://codereview.stackexchange.com/questions/83219/order-of-operations-algorithm-for-calculator
    
    public class OrderOfOperations
    {
        static List<String> contents = new List<String>();
        static String item;
        OrderOfOperations check;

        //Testing
        public static void Main()
        {
            OrderOfOperations go = new OrderOfOperations();
            var a = go.brackets("(12)5");
            Console.WriteLine("Result: " + a);

        }

        public decimal brackets(String s)
        {   //Separate brackets
            check = new OrderOfOperations();
            while (s.Contains(Char.ToString('(')) || s.Contains(Char.ToString('(')))
            {
                for (int o = 0; o < s.Length; o++)
                {
                    try
                    {   //If there is not sign it is treated as a multiplication
                        if ((s[o] == ')' || Char.IsDigit(s[o])) 
                                && s[o + 1] == '(')
                        {                         
                            s = s.Substring(0, o + 1) + "*" + (s.Substring(o + 1));
                        }                                                       
                    }
                    catch (Exception ignored) { }                                
                    if (s[o] == ')')
                    {   //search for a closing bracket
                        for (int i = o; i >= 0; i--)
                        {
                            if (s[i] == '(')
                            {   //search for a opening bracket
                                String inn = s.Substring(i + 1, o);
                                inn = check.recognize(inn);
                                s = s.Substring(0, i) + inn + s.Substring(o + 1);
                                i = o = 0;
                            }
                        }
                    }
                }
                if (s.Contains(Char.ToString('(')) || s.Contains(Char.ToString(')')) ||
                        s.Contains(Char.ToString('(')) || s.Contains(Char.ToString(')')))
                {
                    Console.WriteLine("Error: incorrect brackets placement");
                    return 0;
                }
            }
            s = check.recognize(s);
            return Convert.ToDecimal(s);
        }
        public String recognize(String s)
        {   //method divide String on numbers and operators
            PutIt putIt = new PutIt();
            contents = new List<String>();         
            item = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {   
                if (s[i] >= '0' && s[i] <= '9')
                {   //Strings are added to list, if the scan finds them
                    item = s[i] + item;              
                    if (i == 0)
                    {
                        putIt.put();
                    }
                }
                else
                {
                    if (s[i] == '.')
                    {
                        item = s[i] + item;
                    }
                    else if (s[i] == '-' && (i == 0 || (!Char.IsDigit(s[i - 1]))))
                    {
                        item = s[i] + item;         
                        putIt.put();                   
                    }
                    else
                    {
                        putIt.put();               
                        item += s[i];          
                        putIt.put();                
                        if (s[i] == '|')
                        {   //Add empty String to list, before "|" sign,
                            item += " ";          
                            putIt.put();        
                        }
                    }
                }
            }
            contents = putIt.result(contents, "^", "|");    
            contents = putIt.result(contents, "*", "/");    
            contents = putIt.result(contents, "+", "-");    
            return contents[0];
        }
        public class PutIt
        {

            public void put()
            {
                if (!item.Equals(""))
                {
                    contents.Insert(0, item);
                    item = "";
                }
            }
            public List<String> result(List<String> arrayList, String op1, String op2)
            {
                decimal result = new decimal(0);
                for (int c = 0; c < arrayList.Count; c++)
                {
                    if (arrayList[c].Equals(op1) || arrayList[c].Equals(op2))
                    {
                        if (arrayList[c].Equals("^"))
                        {
                            result = new decimal(Math.Pow(Convert.ToDouble(arrayList[c - 1]), (int.Parse(arrayList[c + 1]))));
                        }
                        else if (arrayList[c].Equals("|"))
                        {
                            result = new decimal(Math.Sqrt(Convert.ToDouble(arrayList[c + 1])));
                        }
                        else if (arrayList[c].Equals("*"))
                        {
                            result = new decimal(Convert.ToDouble(arrayList[c - 1])) *
                                    (new decimal(Convert.ToDouble(arrayList[c + 1])));
                        }
                        else if (arrayList[c].Equals("/"))
                        {
                            result = new decimal(Convert.ToDouble(arrayList[c - 1])) /
                                    (new decimal(Convert.ToDouble(arrayList[c + 1])));
                        }
                        else if (arrayList[c].Equals("+"))
                        {
                            result = new decimal(Convert.ToDouble(arrayList[c - 1])) + (new decimal(Convert.ToDouble(arrayList[c + 1])));
                        }
                        else if (arrayList[c].Equals("-"))
                        {
                            result = new decimal(Convert.ToDouble(arrayList[c - 1])) - (new decimal(Convert.ToDouble(arrayList[c + 1])));
                        }
                        try
                        {   //In a case of to "out of range" ex
                            arrayList.RemoveAt(c);
                            arrayList.Insert(c, result.ToString());
                            arrayList.RemoveAt(c + 1);            
                            arrayList.RemoveAt(c - 1);              
                        }
                        catch (Exception ignored) { }
                    }
                    else
                    {
                        continue;
                    }
                    c = 0;                  
                }
                return arrayList;
            }
        }
    }

}

