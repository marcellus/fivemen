var groupview = $.extend({}, $.fn.datagrid.defaults.view, {
	render: function(target, container, frozen){
		var opts = $.data(target, 'datagrid').options;
		var rows = $.data(target, 'datagrid').data.rows;
		var fields = $(target).datagrid('getColumnFields', frozen);
		
		var table = [];
		var index = 0;
		var groups = this.groups;
		for(var i=0; i<groups.length; i++){
			var group = groups[i];
			
			table.push('<div class="datagrid-group" group-index=' + i + ' style="height:25px;overflow:hidden;border-bottom:1px solid #ccc;">');
			table.push('<table cellspacing="0" cellpadding="0" border="0" style="height:100%"><tbody>');
			table.push('<tr>');
			table.push('<td style="border:0;">');
			if (!frozen){
				table.push('<span style="color:#666;font-weight:bold;">');
				table.push(opts.groupFormatter.call(target, group.fvalue, group.rows));
				table.push('</span>');
			}
			table.push('</td>');
			table.push('</tr>');
			table.push('</tbody></table>');
			table.push('</div>');
			
			table.push('<table cellspacing="0" cellpadding="0" border="0"><tbody>');
			for(var j=0; j<group.rows.length; j++) {
				// get the class and style attributes for this row
				var cls = (index % 2 && opts.striped) ? 'class="datagrid-row-alt"' : '';
				var styleValue = opts.rowStyler ? opts.rowStyler.call(target, index, group.rows[j]) : '';
				var style = styleValue ? 'style="' + styleValue + '"' : '';
				
				table.push('<tr datagrid-row-index="' + index + '" ' + cls + ' ' + style + '>');
				table.push(this.renderRow.call(this, target, fields, frozen, index, group.rows[j]));
				table.push('</tr>');
				index++;
			}
			table.push('</tbody></table>');
		}
		
		$(container).html(table.join(''));
	},
	
	onAfterRender: function(target){
		var opts = $.data(target, 'datagrid').options;
		var view = $(target).datagrid('getPanel').find('div.datagrid-view');
		var view1 = view.children('div.datagrid-view1');
		var view2 = view.children('div.datagrid-view2');
		
		$.fn.datagrid.defaults.view.onAfterRender.call(this, target);
		
		if (opts.rownumbers || opts.frozenColumns.length){
			var group = view1.find('div.datagrid-group');
		} else {
			var group = view2.find('div.datagrid-group');
		}
		$('<td style="border:0"><div class="datagrid-row-expander datagrid-row-collapse" style="width:25px;height:16px;cursor:pointer"></div></td>').insertBefore(group.find('td'));
		
		view.find('div.datagrid-group').each(function(){
			var groupIndex = $(this).attr('group-index');
			$(this).find('div.datagrid-row-expander').bind('click', {groupIndex:groupIndex}, function(e){
				var group = view.find('div.datagrid-group[group-index=' + e.data.groupIndex + ']');
				if ($(this).hasClass('datagrid-row-collapse')){
					$(this).removeClass('datagrid-row-collapse').addClass('datagrid-row-expand');
					group.next('table').hide();
				} else {
					$(this).removeClass('datagrid-row-expand').addClass('datagrid-row-collapse');
					group.next('table').show();
				}
				$(target).datagrid('fixRowHeight');
			});
		});
		
//		view.find('div.datagrid-group').bind('click', function(){
//			var groupIndex = $(this).attr('group-index');
//			
//			var group = view.find('div.datagrid-group[group-index=' + groupIndex + ']');
//			var expander = group.find('div.datagrid-row-expander');
//			if (expander.hasClass('datagrid-row-collapse')){
//				expander.removeClass('datagrid-row-collapse').addClass('datagrid-row-expand');
//				group.next('table').hide();
//			} else {
//				expander.removeClass('datagrid-row-expand').addClass('datagrid-row-collapse');
//				group.next('table').show();
//			}
//		});
	},
	
	onBeforeRender: function(target, rows){
		var opts = $.data(target, 'datagrid').options;
		var groups = [];
		for(var i=0; i<rows.length; i++){
			var row = rows[i];
			var group = getGroup(row[opts.groupField]);
			if (!group){
				group = {
					fvalue: row[opts.groupField],
					rows: [row],
					startRow: i
				};
				groups.push(group);
			} else {
				group.rows.push(row);
			}
		}
		
		function getGroup(fvalue){
			for(var i=0; i<groups.length; i++){
				var group = groups[i];
				if (group.fvalue == fvalue){
					return group;
				}
			}
			return null;
		}
		
		this.groups = groups;
		
		var newRows = [];
		for(var i=0; i<groups.length; i++){
			var group = groups[i];
			for(var j=0; j<group.rows.length; j++){
				newRows.push(group.rows[j]);
			}
		}
		$.data(target, 'datagrid').data.rows = newRows;
	}
});
