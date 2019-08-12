import React from "react";
import "./styles.css";
import SearchIcon from '../../assets/search.png';

export default function SearchBar() {
  return (
    <div className="search-container">
      <form>
        <input placeholder="Type your player" />
        <button type="submit">
            <img src={SearchIcon} alt="Search Button"></img>
        </button>
      </form>
    </div>
  );
}
