<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Rastaclats.Index" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
  
  
  
                    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
                <table style="width:100%; height: 100%;"> 
  <tr>
    <asp:Repeater ID="rptProduct" runat="server" DataSourceID="ProductDataSource" >
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>

        <ItemTemplate>
           

              <td >  <a href="<%# Eval("ProductID", "Product.aspx?ProductID={0}") %>">
                     <asp:Image runat="server" ImageUrl='<%#"~/Image/" + Eval("ProductID") + ".jpg"%>' Height="216px" ></asp:Image>
                   
                    
                  <%#Eval("ProductName") %>
  
                    <%#Eval("Price") %>
                        
                    <%#Eval("Description") %>
                      
                    <div> Quantity <asp:Label ID = "lblQuantity" runat="server" Text=' <%#Eval("Quantity") %>' ></asp:Label>
                   </td>
                       
                     </tr>
          
                
                
        </ItemTemplate>



        <FooterTemplate></ul></FooterTemplate>
    </asp:Repeater>
    <asp:SqlDataSource ID="ProductDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:IdentityConnectionString %>" SelectCommand="SELECT * FROM [Table]"></asp:SqlDataSource>
       

  </table>        
</asp:Content>