﻿using DevExpress.Web;
using System.Web.UI;

public class MyDataViewTemplate : ITemplate {
    public void InstantiateIn(Control container) {
        var dataViewContainer = container as DataViewItemTemplateContainer;
        container.Controls.Add(GetFormLayout(dataViewContainer.DataItem));
    }
    ASPxFormLayout GetFormLayout(object dataItem) {
        var formLayout = new ASPxFormLayout();
        var layoutGroup = formLayout.Items.Add(new LayoutGroup("Item Info")) as LayoutGroup;
        var layoutItemName = new LayoutItem("Name");
        layoutItemName.Controls.Add(new ASPxLabel() { Text = GetData(dataItem, "Name") });
        var layoutItemDecsription = new LayoutItem("Description");
        layoutItemDecsription.Controls.Add(new ASPxLabel() { Text = GetData(dataItem, "Description") });
        layoutGroup.Items.Add(layoutItemName);
        layoutGroup.Items.Add(layoutItemDecsription);
        return formLayout;
    }
    string GetData(object dataObject, string fieldName) {
        return DataBinder.Eval(dataObject, fieldName).ToString();
    }
}