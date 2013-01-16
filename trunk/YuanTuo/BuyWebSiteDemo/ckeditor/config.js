/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	config.toolbar_Full  = [ { name: 'document', items : ['Source','NewPage','Preview' ] }, { name: 'basicstyles', items : ['Bold','Italic','Strike','-','RemoveFormat' ] }, { name: 'clipboard', items : ['Cut','Copy','Paste','PasteText','PasteFromWord','-','Undo','Redo' ] }, { name:'editing', items : [ 'Find','Replace','-','SelectAll','-','Scayt' ] }, '/', { name:'styles', items : [ 'Styles','Format' ] },  { name:'insert', items :['Image','Flash','Table','HorizontalRule','Smiley','SpecialChar','PageBreak' ,'Iframe'] }, { name: 'links', items : [ 'Link','Unlink','Anchor' ] }, { name: 'tools', items :[ 'Maximize','-','About' ] } ]; };
}
