<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateIndex.aspx.cs" Inherits="UI.Index" %>
<!--Force IE6 into quirks mode with this comment tag-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd"><html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">

<!-- **** DESIGN INFORMATION: start head **** --> 
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Editora Saraiva - Segmentação</title>
<link href="Css/Css.css" rel="stylesheet" type="text/css" />
<link href="css/MenuBar.css" rel="stylesheet" media="screen" type="text/css">
<script type="text/javascript" src="Js/Includes.js"></script>
<script type="text/javascript" src="Js/menu-for-applications.js"></script>
</head>
<!-- **** DESIGN INFORMATION: end /head **** --> 


<!-- **** DESIGN INFORMATION: BODY **** --> 
<body>
<div id="framecontent">
	<div id="toplogo"><img src="Images/topo/logo.jpg"></div>
    <div id="toplogin">
    <ul>
    	<li><b>Rodrigo Nobrega</b></li>
        <li>W IT Solutions</li>
    </ul>
    </div>
    
    <div id="topmenu">
 <!-- *******************************************************************************
 DESIGN INFORMATION: start div top 
******************************************************************************** -->   

<div id="mainContentainer">
<div id="mainContent">
		<!-- This <ul><li> list is the source of a menuModel object -->
		<ul id="menuModel" style="display:none">
			<li id="100"><a href="#">Segurança</a>
				<ul width="130">
					<li id="101"><a href="#">Menu 1</a></li>
					<li id="102"><a href="#">Menu 1</a></li>
					<li id="103"><a href="#">Menu 1</a>
						<ul width="150">
							<li id="104"><a href="#">Menu 1</a>	
							<li id="105"><a href="#">Menu 1</a>	
							<li id="106"><a href="#">Menu 1</a>	
						</ul>
					</li>
				</ul>
			</li>

            <li id="200" itemType="separator"></li>
            	<li id="201"><a href="#">Ddos Básicos</a>
				<ul width="130">
					<li id="202"><a href="#">Menu 2</a></li>
					<li id="203"><a href="#">Menu 2</a></li>
					<li id="204"><a href="#">Menu 2</a>
						<ul width="150">
							<li id="205"><a href="#">Menu 2</a>	
							<li id="206"><a href="#">Menu 2</a>	
							<li id="207"><a href="#">Menu 2</a>	
						</ul>
					</li>
				</ul>
			</li>
            
            <li id="300" itemType="separator"></li>
            	<li id="301"><a href="#">Dados Variáveis</a>
				<ul width="130">
					<li id="302"><a href="#">Menu 3</a></li>
					<li id="303"><a href="#">Menu 3</a></li>
					<li id="304"><a href="#">Menu 3</a>
						<ul width="150">
							<li id="305"><a href="#">Menu 3</a>	
							<li id="306"><a href="#">Menu 3</a>	
							<li id="307"><a href="#">Menu 3</a>	
						</ul>
					</li>
				</ul>
			</li>
            
            
            <li id="400" itemType="separator"></li>
            	<li id="401"><a href="#">Importação</a>
				<ul width="130">
					<li id="402"><a href="#">Menu 4</a></li>
					<li id="403"><a href="#">Menu 4</a></li>
					<li id="404"><a href="#">Menu 4</a>
						<ul width="150">
							<li id="405"><a href="#">Menu 4</a>	
							<li id="406"><a href="#">Menu 4</a>	
							<li id="407"><a href="#">Menu 4</a>	
						</ul>
					</li>
				</ul>
			</li>
            
            <li id="500" itemType="separator"></li>
            	<li id="501"><a href="#">Relatórios</a>
				<ul width="130">
					<li id="502"><a href="#">Menu 5</a></li>
					<li id="503"><a href="#">Menu 5</a></li>
					<li id="504"><a href="#">Menu 5</a>
						<ul width="150">
							<li id="505"><a href="#">Menu 5</a>	
							<li id="506"><a href="#">Menu 5</a>	
							<li id="507"><a href="#">Menu 5</a>	
						</ul>
					</li>
				</ul>
			</li>            
            

		</ul>	
		<!-- End data source for the menu -->
		<div id="menuDiv"></div>
	</div>
</div>
    
<!-- *******************************************************************************
 DESIGN INFORMATION: start div top 
******************************************************************************** -->    
    </div>
</div>

<!-- *******************************************************************************
 DESIGN INFORMATION: start div content 
******************************************************************************** -->  
<div id="maincontent">
  <div class="contentform">
	<div id="formtitulo">
	
	<div id="botoesform">
	    <ul>
	        <li><a href="#"><asp:Image ID="btnSalvar" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="Images/Icones/salvar.gif"/> Salvar</a></li>
	        <li class="separator"></li>
	        <li><a href="#"><asp:Image ID="btnExcluir" runat="server" ToolTip="Excluir" ImageAlign="AbsMiddle" ImageUrl="Images/Icones/cancelar.gif"/> Excluir</a></li>
	    </ul>
	</div>

	</div>
	
	
    <div id="formgeral">
    
    <table width="99%" align="center" border="0" cellspacing="4" cellpadding="0" id="formfont">
      <tr>
        <td>Teste 1</td>
        <td>Teste 2</td>
        <td>Teste 3</td>
        <td>Teste 4</td>
      </tr>
    </table>

    </div>
  </div>
</div>
<!-- *******************************************************************************
 DESIGN INFORMATION: start div content 
******************************************************************************** -->  
	<script type="text/javascript">
	var menuModel = new DHTMLSuite.menuModel();
	DHTMLSuite.configObj.setCssPath('css/');
	menuModel.addItemsFromMarkup('menuModel');
	menuModel.setMainMenuGroupWidth(00);	
	menuModel.init();
	var menuBar = new DHTMLSuite.menuBar();
	menuBar.addMenuItems(menuModel);
	menuBar.setTarget('menuDiv');
	menuBar.init();	
	</script>

</body>
</html>
<!-- **** DESIGN INFORMATION: BODY **** --> 