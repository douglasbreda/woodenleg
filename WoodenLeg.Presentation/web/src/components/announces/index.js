import React from "react";
import { MdDirectionsRun, MdEuroSymbol } from "react-icons/md";
import menuIcon from "../../assets/menu.png";
import buyIcon from "../../assets/buy.png";
import "./styles.css";

export default function Recent() {
  return (
    <>
      <h5>Recent Ads</h5>
      <div className="main-container">
        <ul>
          <li>
            <img
              src="https://s.glbimg.com/es/sde/f/2019/07/01/ac71f3ebf82fb819599967ea8bff8513_140x140.png"
              alt="test"
            />
            <footer>
              <div className="player-info">
                <MdDirectionsRun />
                <text>Everton Cebolinha</text>
              </div>
              <div className="player-info">
                <MdEuroSymbol />
                <text>1000,00</text>
              </div>
            </footer>
            <div className="buttons">
              <button type="button">
                <img src={menuIcon} alt="Details" />
              </button>
              <button type="button">
                <img src={buyIcon} alt="Details" />
              </button>
            </div>
          </li>
        </ul>
      </div>
    </>
  );
}
