import React from "react";
import "./Announce.css";
import { MdDirectionsRun, MdEuroSymbol } from "react-icons/md";
import menuIcon from "../../assets/menu.png";
import buyIcon from "../../assets/buy.png";
import NavBar from "../../components/navbar";

export default function Announce() {
  return (
    <div>
      <NavBar />
      <div className="main-container">
        <ul>
          <li>
            <img
              src="https://s.glbimg.com/es/sde/f/2019/07/01/ac71f3ebf82fb819599967ea8bff8513_140x140.png"
              alt="test"
            />
            <footer>
              <MdDirectionsRun />
              <p>Éverton Cebolinha</p>
              <MdEuroSymbol />
              <p>1000,00</p>
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

          <li>
            <img
              src="https://s.glbimg.com/es/sde/f/2019/07/01/ac71f3ebf82fb819599967ea8bff8513_140x140.png"
              alt="test"
            />
            <footer>
              <MdDirectionsRun />
              <p>Éverton Cebolinha</p>
              <MdEuroSymbol />
              <p>1000,00</p>
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

          <li>
            <img
              src="https://s.glbimg.com/es/sde/f/2019/07/01/ac71f3ebf82fb819599967ea8bff8513_140x140.png"
              alt="test"
            />
            <footer>
              <MdDirectionsRun />
              <p>Éverton Cebolinha</p>
              <MdEuroSymbol />
              <p>1000,00</p>
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

          <li>
            <img
              src="https://s.glbimg.com/es/sde/f/2019/07/01/ac71f3ebf82fb819599967ea8bff8513_140x140.png"
              alt="test"
            />
            <footer>
              <MdDirectionsRun />
              <p>Éverton Cebolinha</p>
              <MdEuroSymbol />
              <p>1000,00</p>
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

          <li>
            <img
              src="https://s.glbimg.com/es/sde/f/2019/07/01/ac71f3ebf82fb819599967ea8bff8513_140x140.png"
              alt="test"
            />
            <footer>
              <MdDirectionsRun />
              <p>Éverton Cebolinha</p>
              <MdEuroSymbol />
              <p>1000,00</p>
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

          <li>
            <img
              src="https://s.glbimg.com/es/sde/f/2019/07/01/ac71f3ebf82fb819599967ea8bff8513_140x140.png"
              alt="test"
            />
            <footer>
              <MdDirectionsRun />
              <p>Éverton Cebolinha</p>
              <MdEuroSymbol />
              <p>1000,00</p>
              {/* <img className="team-image" src="https://s.glbimg.com/es/sde/f/equipes/2014/04/14/gremio_60x60.png" alt="Team"></img>
            <p>Grêmio</p> */}
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
    </div>
  );
}
