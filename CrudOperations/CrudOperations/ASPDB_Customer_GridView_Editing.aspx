<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ASPDB_Customer_GridView_Editing.aspx.cs" Inherits="CrudOperations.ASPDB_Customer_GridView_Editing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">        
            <div>
           <asp:GridView ID="GridView1" runat="server" Caption="Customer Editing" AutoGenerateColumns="false" 
                HorizontalAlign="Center" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" >
                <HeaderStyle BackColor="Yellow" ForeColor="Red" />
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
                           <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" />
                           <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are u Sure of deleting the record?')"/>
                       </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="btnUpdate" runat="server" Text="Update" CommandName="Update" />
                             <asp:LinkButton ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
                
            </asp:GridView>
        </div>
    </form>
</body>
</html>
