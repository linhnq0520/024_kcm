var flow_form_ab=[];
function flowClientVal()
{
	return JSON.stringify(flow_form_ab);
}
showConnectionInfo = function () {
  //alert("flow_form_ab=>"+JSON.stringify(flow_form_ab));
 },
hideConnectionInfo = function () {
  flow_form_ab=[];
},
connections = [],
updateConnections = function (conn, remove) {
  if (!remove) 
    connections.push(conn);
  else {
    var idx = -1;
    for (var i = 0; i < connections.length; i++) {
      if (connections[i] == conn) {
        idx = i;
        break;
      }
    }
    if (idx != -1) 
      connections.splice(idx, 1);
  }
  if (connections.length > 0) {
    flow_form_ab = [];
    for (var j = 0; j < connections.length; j++) {
      var s={};
      s["sourceId"]=connections[j].sourceId+"";
      s["targetId"]=connections[j].targetId+"";
      flow_form_ab.push(s);
    }
    showConnectionInfo();
  } else
    hideConnectionInfo();
};

var canvas = document.getElementById("canvas");
// setup some defaults for jsPlumb.
    var instance = jsPlumb.getInstance({
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
            [ "Label", { label: "Kéo", id: "label", cssClass: "aLabel" }]
        ],
        Container: "canvas"
    });

    instance.registerConnectionType("basic", { anchor:"Continuous", connector:"StateMachine" });

    window.jsp = instance;

    var windows = jsPlumb.getSelector(".statemachine-demo .w");

    // bind a click listener to each connection; the connection is deleted. you could of course
    // just do this: instance.bind("click", instance.deleteConnection), but I wanted to make it clear what was
    // happening.
    instance.bind("click", function (c) {
        instance.deleteConnection(c);
    });

    // bind a connection listener. note that the parameter passed to this function contains more than
    // just the new connection - see the documentation for a full list of what is included in 'info'.
    // this listener sets the connection's internal
    // id as the label overlay's text.
    instance.bind("connection", function (info) {
        info.connection.getOverlay("label").setLabel("");//info.connection.id
    });

    // bind a double click listener to "canvas"; add new node when this occurs.
    //jsPlumb.on(canvas, "dblclick", function(e) {
     //   newNode(e.offsetX, e.offsetY);
    //});

    //
    // initialise element as connection targets and source.
    //
    var initNode = function(el) {

        // initialise draggable elements.
        instance.draggable(el);

        instance.makeSource(el, {
            filter: ".ep",
            anchor: "Continuous",
            connectorStyle: { stroke: "#5c96bc", strokeWidth: 2, outlineStroke: "transparent", outlineWidth: 4 },
            connectionType:"basic",
            extract:{
                "action":"the-action"
            },
            maxConnections: 15,
            onMaxConnections: function (info, e) {
                alert(" Tối đa kéo đến (" + info.maxConnections + ") đối tượng");
            }
        });

        instance.makeTarget(el, {
            dropOptions: { hoverClass: "dragHover" },
            anchor: "Continuous",
            allowLoopback: true
        });

        // this is not part of the core demo functionality; it is a means for the Toolkit edition's wrapped
        // version of this demo to find out about new nodes being added.
        //
        instance.fire("jsPlumbDemoNodeAdded", el);
    };

	var all_node_flow = [];
    var newNode = function(x, y,n,c) {
        var d = document.createElement("div");
        var id = jsPlumbUtil.uuid();
        d.className = "w";
        d.id = c;
        d.innerHTML = n + "<div class=\"ep\"></div>";
        d.style.left = x + "px";
        d.style.top = y + "px";
        instance.getContainer().appendChild(d);
        initNode(d);
        
        all_node_flow.push(d);
        
        return d;
    };

    // suspend drawing and initialise.
    instance.batch(function () {       
       	instance.bind("connection", function (info, originalEvent) {
        	updateConnections(info.connection);
		});
      	instance.bind("connectionDetached", function (info, originalEvent) {
        	updateConnections(info.connection, true);
      	});
  
      	instance.bind("connectionMoved", function (info, originalEvent) {
        	updateConnections(info.connection, true);
      	});
    });

    jsPlumb.fire("jsPlumbDemoLoaded", instance);