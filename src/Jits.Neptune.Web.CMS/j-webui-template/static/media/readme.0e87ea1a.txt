.malibu-desktop-uSelectMulti:focus-within
  .malibu-desktop-uSelectMulti-input_select {
  box-shadow: 0 0 0 2px $color_main inset;
}
.malibu-desktop-uSelectMulti_menu {
  position: absolute;
  right: 14px;
  /* width: fit-content; */
  min-width: 300%;
  top: 35px;
  border: 1px solid #cbd6e2;
  box-sizing: border-box;
  z-index: 3;
  background: #ffffff;
  border-radius: 4px;
  max-height: 200px;
  overflow: auto;
  scrollbar-width: thin;
  scrollbar-color: rgba(73, 79, 89, 0.5) #f5f6f7;
  display: none;
  outline: none;
}
.malibu-desktop-uSelectMulti_menu-search-input {
  border: none;
  padding-left: 8px;
  border-radius: 4px;
  height: 30px;
  display: flex;
  align-items: center;
  margin: 12px 12px 8px 12px;
  width: calc(100% - 24px);
  border: 1px solid #e3e4e5;
  box-sizing: border-box;
  border-radius: 4px;
  outline: none;
}
.malibu-desktop-uSelectMulti-input_select {
  background: transparent;
  /* light gray */
  margin-right: 14px;
  box-shadow: 0 0 0 1px #cbd6e2 inset;
  border: unset !important;
  box-sizing: border-box;
  border-radius: 4px;
  outline: none;
  font-size: 14px;
  line-height: 16px;
  padding: 7px 8px;
  padding-right: 32px;
  color: #494f59;
  width: 100%;
  cursor: pointer;
  position: relative;
  z-index: 1;
  white-space: nowrap;
  -o-text-overflow: ellipsis;
  -ms-text-overflow: ellipsis;
  text-overflow: ellipsis;
  overflow: hidden;
}

.malibu-desktop-uSelectMulti:focus-within
  .malibu-desktop-uSelectMulti_menu {
  display: block;
}
.malibu-desktop-uSelectMulti_menu::-webkit-scrollbar-track {
  background-color: #f5f6f7;
}

.malibu-desktop-uSelectMulti_menu::-webkit-scrollbar {
  height: 8px;
  width: 8px;
  background-color: #f5f6f7;
}

.malibu-desktop-uSelectMulti_menu::-webkit-scrollbar-thumb:horizontal:hover,
.malibu-desktop-uSelectMulti_menu::-webkit-scrollbar-thumb:vertical:hover {
  /* hover thumb styles */
  cursor: pointer;
  background-color: black;
}

.malibu-desktop-uSelectMulti_menu::-webkit-scrollbar-thumb {
  background-color: rgba(19, 20, 21, 0.5);
  border-radius: 8px;
}

.malibu-desktop-uSelectMulti_menu > li {
  list-style: none;
  padding: 8px 20px;
  padding-left: 26px;
  cursor: pointer;
  font-size: 14px;
  overflow: hidden;
  white-space: nowrap;
  -o-text-overflow: ellipsis;
  -ms-text-overflow: ellipsis;
  text-overflow: ellipsis;
  color: rgba(19, 20, 21, 0.5);
  outline: none;
}
.malibu-desktop-uSelectMulti_menu > li:hover {
  background-color: $skin_background_hover;
}
.malibu-desktop-uSelectMulti-input_select:focus
  ~ .malibu-desktop-uSelectMulti_drop {
  transform: rotate(180deg);
}
.malibu-desktop-uSelectMulti {
  position: relative;
}
.malibu-desktop-uSelectMulti_drop {
  position: absolute;
  right: 8px;
  top: 3px;
  cursor: pointer;
}
.malibu-desktop-uSelectMulti-item.malibu-close > i {
  transform: rotate(-90deg);
}
.malibu-is_parent{
  display: flex;
  align-items: center;
  padding: 4.5px 20px  !important;
  padding-left: 6px !important;
}
.malibu-child{
  padding-left: 46px !important;
}
.malibu-child.malibu-is_parent{
  padding-left: 27px !important;
}
.malibu-child-2{
  padding-left: 64px !important;
}