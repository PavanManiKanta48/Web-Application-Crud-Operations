<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AspDB_Customer.aspx.cs" Inherits="Webform_Crud_Operations.AspDB_Customer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" Caption="Customer Details"  AutoGenerateColumns="false"  OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" >
                <HeaderStyle  backcolor="WhiteSmoke" ForeColor="SeaGreen" Font-Size="X-Large"/>
                <RowStyle ForeColor="Yellow" BackColor="Tomato" />
                <AlternatingRowStyle ForeColor="Teal" BackColor="Tan" />
                <Columns>
                     <asp:BoundField HeaderText="Customer id" DataField="Custid" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
                     <asp:BoundField HeaderText="Name" DataField="Name" />
                    <asp:BoundField HeaderText="Balance" DataField="Balance" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField HeaderText="City" DataField="City"  />
                    <asp:CheckBoxField HeaderText="Is-Active" DataField="Status" ItemStyle-HorizontalAlign="Center" ReadOnly="true"/>
                    <asp:TemplateField HeaderText="Actions" ItemStyle-ForeColor="Blue" ItemStyle-BackColor="White">
                   <ItemTemplate>
                    <asp:LinkButton ID="btnInsert" runat="server" Text="Insert" CommandName="Insert" />
                    <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                    <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick ="return confirm('Are you sure of deleting the current record?')" /> 
                   </ItemTemplate>
                     <EditItemTemplate>
                      <asp:LinkButton ID="btnUpdate" runat="server" Text="Update" CommandName="Update" />
                      <asp:LinkButton ID="LinkCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                     </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
