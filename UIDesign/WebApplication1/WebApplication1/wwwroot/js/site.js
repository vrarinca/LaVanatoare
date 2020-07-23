// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function(){
    $('.modal').modal();
    $('.dropdown-trigger').dropdown();
 });

 $(document).ready(function(){
    $('select').formSelect();
  });

  function selectItem(){
      var el =document.getElementById("newUserBtn");
      el.classList.remove("darken-3");
      el.classList.add("darken-4");
  }

  function newUser(){
   var el =document.getElementById("newUserBtn");
   el.classList.add("darken-3");
   el.classList.remove("darken-4");
  }
 
  