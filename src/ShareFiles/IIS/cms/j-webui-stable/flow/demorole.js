var flow_form_abRole=[];
function RoleClientVal()
{
	return JSON.stringify(flow_form_abRole);
}
function RoleClientValCheck()
{
	return JSON.stringify(all_val_select_role);
}
function RoleClientUserMail()
{
	return JSON.stringify(all_val_user_role);
}

RoleshowConnectionInfo = function () {
  //alert("flow_form_ab=>"+JSON.stringify(flow_form_ab));
 },
RolehideConnectionInfo = function () {
  flow_form_abRole=[];
},
Roleconnections = [],
RoleupdateConnections = function (conn, remove) {
  if (!remove) 
    Roleconnections.push(conn);
  else {
    var idx = -1;
    for (var i = 0; i < Roleconnections.length; i++) {
      if (Roleconnections[i] == conn) {
        idx = i;
        break;
      }
    }
    if (idx != -1) 
      Roleconnections.splice(idx, 1);
  }
  if (Roleconnections.length > 0) {
    flow_form_abRole = [];
    for (var j = 0; j < Roleconnections.length; j++) {
      var s={};
      s["sourceId"]=Roleconnections[j].sourceId+"";
      s["targetId"]=Roleconnections[j].targetId+"";
      flow_form_abRole.push(s);
    }
    RoleshowConnectionInfo();
  } else
    RolehideConnectionInfo();
};

// setup some defaults for jsPlumb.
    var instanceRole = jsPlumb.getInstance({
        Endpoint: ["Dot", {radius: 2}],
        Connector:"StateMachine",
        HoverPaintStyle: {stroke: "#1e8151", strokeWidth: 2 },
        ConnectionOverlays: [
            [ "Arrow", {
                location: 1,
                id: "arrow",
                length: 14,
                foldback: 0.8
            } ],
            [ "Label", { label: "Quyền đọc ghi", id: "label", cssClass: "aLabel" }]
        ],
        Container: "canvasRole"
    });

    instanceRole.registerConnectionType("basic", { anchor:"Continuous", connector:"StateMachine" });

    window.jsp = instanceRole;

    var canvasRole = document.getElementById("canvasRole");
    var windows = jsPlumb.getSelector(".statemachine-role .w");

    // bind a click listener to each connection; the connection is deleted. you could of course
    // just do this: instanceRole.bind("click", instance.deleteConnection), but I wanted to make it clear what was
    // happening.
    instanceRole.bind("click", function (c) {
        instanceRole.deleteConnection(c);
    });

    // bind a connection listener. note that the parameter passed to this function contains more than
    // just the new connection - see the documentation for a full list of what is included in 'info'.
    // this listener sets the connection's internal
    // id as the label overlay's text.
    instanceRole.bind("connection", function (info) {
        info.connection.getOverlay("label").setLabel("");
    });



    //
    // initialise element as connection targets and source.
    //
    var initNodeRole = function(el) {

        // initialise draggable elements.
        instanceRole.draggable(el);

        instanceRole.makeSource(el, {
            filter: ".ep",
            anchor: "Continuous",
            connectorStyle: { stroke: "#5c96bc", strokeWidth: 2, outlineStroke: "transparent", outlineWidth: 4 },
            connectionType:"basic",
            extract:{
                "action":"the-action"
            },
            maxConnections: 15,
            onMaxConnections: function (info, e) {
                alert("Tối đa quản lý (" + info.maxConnections + ") tài khoản");
            }
        });

        instanceRole.makeTarget(el, {
            dropOptions: { hoverClass: "dragHover" },
            anchor: "Continuous",
            allowLoopback: true
        });

        // this is not part of the core demo functionality; it is a means for the Toolkit edition's wrapped
        // version of this demo to find out about new nodes being added.
        //
        instanceRole.fire("jsPlumbRoleAppNodeAdded", el);
    };

	var all_node_Role = [];
   var newNodeRole = function(x, y,n,c) {
        var d = document.createElement("div");
        var id = jsPlumbUtil.uuid();
        d.className = "w";
        d.id = c;
        d.innerHTML = n + "<div class=\"ep\"></div>";
        d.style.left = x + "px";
        d.style.top = y + "px";
        instanceRole.getContainer().appendChild(d);
        initNodeRole(d);
        
        all_node_Role.push(d);
        
        return d;
    };

    // suspend drawing and initialise.
    instanceRole.batch(function () {
       	instanceRole.bind("connection", function (info, originalEvent) {
        	RoleupdateConnections(info.connection);
		});
      	instanceRole.bind("connectionDetached", function (info, originalEvent) {
        	RoleupdateConnections(info.connection, true);
      	});
  
      	instanceRole.bind("connectionMoved", function (info, originalEvent) {
        	RoleupdateConnections(info.connection, true);
      	});
    });

    jsPlumb.fire("jsPlumbRoleAppLoaded", instanceRole);
    
    var all_val_select_role = [];
    var all_val_user_role = [];
function callAllValRole()
{
	all_val_select_role = [];
	all_val_user_role = [];
	$(".clsCheckChart").each(function(index) {
		var ob_ ={};
		ob_["user"] = $(this).attr("user");
		ob_["role"] = $(this).attr("role");
		ob_["val"] = $(this).prop("checked")+"";
  		all_val_select_role.push(ob_);
	});
	$(".roleEmail").each(function(index) {
		var ob_ ={};
		ob_["user"] = $(this).attr("user");
		ob_["email"] = $(this).val().trim();
  		all_val_user_role.push(ob_);
	});
}
function callSetValRole(a)
{
	var aa = JSON.parse(a);
	$(".clsCheckChart").each(function(index) {
		if(aa[$(this).attr("role")]!=null)
		{
			var str__ = ";"+aa[$(this).attr("role")]+";";
			if(str__.includes(";"+$(this).attr("user")+";"))
				$(this).prop( "checked", true );
		}
	});
}
    